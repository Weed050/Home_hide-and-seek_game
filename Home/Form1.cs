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
            OutsideWithDoor frontYard = new OutsideWithDoor(true, "podwórko przed domem", "metalowe drzwi");
            OutsideWithDoor backYard = new OutsideWithDoor(false, "podwórko za domem", "metalowe drzwi z plastikow¹ klamk¹");
            OutsideWithDoor garden = new OutsideWithDoor(false,"ogród","pergola pokryta ró¿ami");
            RoomWithDoor livingRoom = new RoomWithDoor("kwiatki w doniczkach", "salon", "dêbowe drzwi");
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