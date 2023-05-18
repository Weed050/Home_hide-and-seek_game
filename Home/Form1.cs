namespace Home
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateObjects();
        }

        public void CreateObjects()
        {
            OutsideWithDoor frontYard = new OutsideWithDoor(true, "podw�rko przed domem", "metalowe drzwi");
            OutsideWithDoor backYard = new OutsideWithDoor(false, "podw�rko za domem", "metalowe drzwi z plastikow� klamk�");
            OutsideWithDoor garden = new OutsideWithDoor(false,"ogr�d","pergola pokryta r�ami");
            RoomWithDoor livingRoom = new RoomWithDoor("kwiatki w doniczkach", "salon", "d�bowe drzwi");
            RoomWithDoor diningRoom = new RoomWithDoor("paprotki", "jadalnia", "klonowe drzwi");
            RoomWithDoor kitchen = new RoomWithDoor("obrazy", "kuchnia","bukowe drewniane drzwi");
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
            diningRoom.Exits = new Location[] {livingRoom,kitchen };
            kitchen.Exits = new Location[] { diningRoom };
        }
    }
}