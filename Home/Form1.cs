namespace Home
{
    public partial class Form1 : Form
    {
        Location currentLocation;

        OutsideWithDoor frontYard;
        OutsideWithDoor backYard;
        OutsideWithHidingPlace garden;
        OutsideWithHidingPlace driveway;

        Room diningRoom;
        Room stairs;
        RoomWithHidingPlace BigSleepingRoom;
        RoomWithHidingPlace MiddleSleepingRoom;
        RoomWithHidingPlace BathRoom;
        RoomWithHidingPlace passageway;
        RoomWithDoor livingRoom;
        RoomWithDoor kitchen;

        Opponent opponent;
        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            MoveToANewLocation(livingRoom);
        }


        private void CreateObjects()
        {
            driveway = new OutsideWithHidingPlace(true, "droga dojazdowa", "gara¿");
            BigSleepingRoom = new RoomWithHidingPlace("kwiatek", "du¿a sypialnia", "pod ³ó¿kiem");
            MiddleSleepingRoom = new RoomWithHidingPlace("obraz pla¿y", "œrednia sypialnia", "pod ³ó¿kiem");
            BathRoom = new RoomWithHidingPlace("umywalka", "du¿a sypialnia", "pod prysznicem");
            passageway = new RoomWithHidingPlace("obrazek z psem", "korytarz", "szafa œcienna");

            stairs = new Room("drewniana porêcz", "schody");

            frontYard = new OutsideWithDoor(true, "podwórko przed domem", "metalowe drzwi", "w namiocie");

            backYard = new OutsideWithDoor(false, "podwórko za domem", "metalowe drzwi z plastikow¹ klamk¹", "pod sto³em");

            garden = new OutsideWithHidingPlace(false, "ogród", "szopa");

            livingRoom = new RoomWithDoor("kwiatki w doniczkach", "salon", "dêbowe drzwi", "szafa œcienna");

            diningRoom = new Room("paprotki", "jadalnia");

            kitchen = new RoomWithDoor("obrazy", "kuchnia", "bukowe drewniane drzwi", "szafka");

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
            stairs.Exits = new Location[]
            {
                livingRoom,passageway
            };
            passageway.Exits = new Location[]{
                stairs,BathRoom,BigSleepingRoom,MiddleSleepingRoom
            };
            BigSleepingRoom.Exits = new Location[]{
                passageway
            };
            MiddleSleepingRoom.Exits = new Location[]{
                passageway
            };
            BathRoom.Exits = new Location[]{
                passageway
            };
            livingRoom.Exits = new Location[] { diningRoom };
            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            kitchen.Exits = new Location[] { diningRoom };
            driveway.Exits = new Location[] { frontYard, backYard };

            frontYard.DoorLocation = livingRoom;
            backYard.DoorLocation = kitchen;
            livingRoom.DoorLocation = frontYard;
            kitchen.DoorLocation = backYard;
            opponent = new Opponent(frontYard);
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
            MoveToANewLocation(currentLocation.Exits[Exits.SelectedIndex]);
        }

        private void goThroughTheDoor_Click(object sender, EventArgs e)
        {
            IHasExteriorDoor location = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(location.DoorLocation);
        }

        private void hideYourSelf_Click(object sender, EventArgs e)
        {
            for (int i = 10; i > 0; i--)
            {
                opponent.Move();
                DescriptionBox.Text = i.ToString();
                Update();
                Thread.Sleep(200);
            }
            DescriptionBox.Text = "Gotowy czy nie, idê!";
            Update();
            Thread.Sleep(1500);
            DescriptionBox.Text = "";
            Update();
        }



        private void checkOpponent_Click(object sender, EventArgs e)
        {

        }
    }
}