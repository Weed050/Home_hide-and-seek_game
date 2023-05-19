namespace Home
{
    public partial class Form1 : Form
    {
        Location currentLocation;
        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;
        Outside garden;
        RoomWithDoor livingRoom;
        Room diningRoom;
        RoomWithDoor kitchen;
        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            MoveToANewLocation(garden);
        }
        public void CreateObjects()
        {

            frontYard = new OutsideWithDoor(true, "podw�rko przed domem", "metalowe drzwi");
            frontYard.DoorLocation =  livingRoom;

            backYard = new OutsideWithDoor(false, "podw�rko za domem", "metalowe drzwi z plastikow� klamk�");
            backYard.DoorLocation = kitchen;

            garden = new Outside(false, "ogr�d");

            livingRoom = new RoomWithDoor("kwiatki w doniczkach", "salon", "d�bowe drzwi");
            livingRoom.DoorLocation = frontYard ;

            diningRoom = new Room("paprotki", "jadalnia");

            kitchen = new RoomWithDoor("obrazy", "kuchnia", "bukowe drewniane drzwi");
            kitchen.DoorLocation = backYard;

            frontYard.Exits = new Location[]
            {
                garden,backYard
            };
            backYard.Exits = new Location[]
            {
                garden,frontYard
            };
            garden.Exits = new Location[]
            {
                frontYard,backYard
            };
            livingRoom.Exits = new Location[] { diningRoom };
            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            kitchen.Exits = new Location[] { diningRoom };
        }




        private void MoveToANewLocation(Location loc)
        {
            this.currentLocation = loc;
            Exits.Items.Clear();
            foreach (Location l in currentLocation.Exits)
            {
                Exits.Items.Add(l.Name);
            }
            Exits.SelectedIndex = 0;
            DescriptionBox.Text = currentLocation.Description;

            for (int i = 0; i < currentLocation.Exits.Length; i++)
            {

                if (currentLocation is IHasExteriorDoor)
                {
                    IHasExteriorDoor location2 = currentLocation as IHasExteriorDoor;
                    DescriptionBox.Text += location2.DoorDescription;
                }

                DescriptionBox.Text += currentLocation.Exits[i].Description;
                ButtonVisibility(currentLocation);
            }
        }
        public void ButtonVisibility(Location location)
        {
            goThroughTheDoor.Visible = (location is IHasExteriorDoor);
        }

        private void goThere_Click(object sender, EventArgs e)
        {
            int i;
            i = Exits.SelectedIndex;
            MoveToANewLocation (currentLocation.Exits[i]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {

            IHasExteriorDoor location3 = null;
            if (currentLocation is RoomWithDoor)
            {
                 location3 = currentLocation as IHasExteriorDoor;
                MoveToANewLocation(location3.DoorLocation);

            }
            if (currentLocation is OutsideWithDoor)
            {
                location3 = currentLocation as IHasExteriorDoor;
                Location location4 = location3.DoorLocation as Location;
                MoveToANewLocation(location4);

            }
        }
    }
}