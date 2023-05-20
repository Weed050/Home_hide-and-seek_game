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
            MoveToANewLocation(livingRoom);
        }
       
        
        private void CreateObjects()
        {

            frontYard = new OutsideWithDoor(true, "podwórko przed domem", "metalowe drzwi");

            backYard = new OutsideWithDoor(false, "podwórko za domem", "metalowe drzwi z plastikow¹ klamk¹");

            garden = new Outside(false, "ogród");

            livingRoom = new RoomWithDoor("kwiatki w doniczkach", "salon", "dêbowe drzwi");

            diningRoom = new Room("paprotki", "jadalnia");

            kitchen = new RoomWithDoor("obrazy", "kuchnia", "bukowe drewniane drzwi");

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

            frontYard.DoorLocation = livingRoom;
            backYard.DoorLocation = kitchen;
            livingRoom.DoorLocation = frontYard;
            kitchen.DoorLocation = backYard;

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
        private void ButtonVisibility(Location location)
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
            IHasExteriorDoor location = currentLocation as IHasExteriorDoor;

            MoveToANewLocation(location.DoorLocation);
            //IHasExteriorDoor location3 = null;
            //if (currentLocation is RoomWithDoor)
            //{
            //    location3 = currentLocation as IHasExteriorDoor;
            //    

            //}
            //if (currentLocation is OutsideWithDoor)
            //{
            //    location3 = currentLocation as IHasExteriorDoor;
            //    Location location4 = location3.DoorLocation as Location;
            //    MoveToANewLocation(location4);
            //    //funkcja do popawienia
            //}
        }
    }
}