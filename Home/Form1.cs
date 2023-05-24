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
        int count;
        int numberOfPassedRooms;

        Opponent opponent;
        public Form1()
        {
            InitializeComponent();
            CreateObjects();
            MoveToANewLocation(livingRoom);
            RestartGame();
        }


        private void CreateObjects()
        {
            driveway = new OutsideWithHidingPlace(true, "droga dojazdowa", "garaø");
            BigSleepingRoom = new RoomWithHidingPlace("kwiatek", "duøa sypialnia", "pod ≥Ûøkiem");
            MiddleSleepingRoom = new RoomWithHidingPlace("obraz plaøy", "úrednia sypialnia", "pod ≥Ûøkiem");
            BathRoom = new RoomWithHidingPlace("umywalka", "≥azienka", "pod prysznicem");
            passageway = new RoomWithHidingPlace("obrazek z psem", "korytarz", "szafa úcienna");

            stairs = new Room("drewniana porÍcz", "schody");

            frontYard = new OutsideWithDoor(true, "podwÛrko przed domem", "metalowe drzwi", "w namiocie");

            backYard = new OutsideWithDoor(false, "podwÛrko za domem", "metalowe drzwi z plastikowπ klamkπ", "pod sto≥em");

            garden = new OutsideWithHidingPlace(false, "ogrÛd", "szopa");

            livingRoom = new RoomWithDoor("kwiatki w doniczkach", "salon", "dÍbowe drzwi", "szafa úcienna");

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
            livingRoom.Exits = new Location[] { diningRoom, stairs };
            diningRoom.Exits = new Location[] { livingRoom, kitchen };
            kitchen.Exits = new Location[] { diningRoom };
            driveway.Exits = new Location[] { frontYard, backYard };

            frontYard.DoorLocation = livingRoom;
            backYard.DoorLocation = kitchen;
            livingRoom.DoorLocation = frontYard;
            kitchen.DoorLocation = backYard;
            opponent = new Opponent(frontYard);
        }



        private void RedrawForm()
        {

        }
        void VisibleButtons()
        {
            goThere.Visible = true;
            Exits.Visible = true;
            goThroughTheDoor.Visible = true;
            checkOpponent.Visible = true;
        }
        private void RestartGame()
        {
            DescriptionBox.Text = "";
            goThere.Visible = false;
            Exits.Visible = false;
            goThroughTheDoor.Visible = false;
            checkOpponent.Visible = false;
        }
        private void MoveToANewLocation(Location loc)
        {
            if (loc != null)
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

                //text in checkOpponent button
                if (currentLocation is IHidingPlace)
                {
                    IHidingPlace place = currentLocation as IHidingPlace;
                    checkOpponent.Text = "Sprawdü " + place.Hideout + ".";
                }
                else
                    checkOpponent.Text = "---";
                this.Text = currentLocation.Name;
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
            numberOfPassedRooms++;
            IHasExteriorDoor location = currentLocation as IHasExteriorDoor;
            MoveToANewLocation(location.DoorLocation);
        }

        private void hideYourSelf_Click(object sender, EventArgs e)
        {
            VisibleButtons();
            for (int i = 10; i > 0; i--)
            {
                opponent.Move();
                DescriptionBox.Text = i.ToString();
                Update();
                Thread.Sleep(200);
            }
            DescriptionBox.Text = "Gotowy czy nie, idÍ!";
            Update();
            Thread.Sleep(1500);
            DescriptionBox.Text = currentLocation.Description;
            this.Text = currentLocation.Name;
            Update();
            numberOfPassedRooms++;
        }



        private void checkOpponent_Click(object sender, EventArgs e)
        {
            count++;
            if (opponent.Check(this.currentLocation))
            {
                MessageBox.Show( "Znaza≥eú mnie w  "+ count +"  ruchach. \n W miÍdzyczasie przeszed≥eú przez "+numberOfPassedRooms+" lokalizacji.","Brawo!");
                RestartGame();
            }
            else
            {
                DescriptionBox.Text = "èle, szukaj dalej.";
                Update();
                Thread.Sleep (1500);
                DescriptionBox.Text = currentLocation.Description;
                Update();
            }
        }
    }
}