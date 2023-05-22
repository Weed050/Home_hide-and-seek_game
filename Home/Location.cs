using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home
{
    abstract class Location
    {
        public Location(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }
        public Location[] Exits;
        public virtual string Description
        {
            get
            {
                string description = "Stoisz w " + Name +
                        ". I widzisz wyjścia do następujących lokalizacji: ";
                for (int i = 0; i < Exits.Length; i++)
                {
                    description += Exits[i].Name;
                    if (i < Exits.Length - 1)
                        description += ", ";
                }
                description += ".";
                return description;
            }
        }
    }


    class Room : Location
    {
        public Room(string decoration, string Name) : base(Name)
        {
            this.Decoration = decoration;
        }
        private readonly string Decoration;
        public override string Description
        {
            get
            {
                string desc = " W " + Name + " jest " + Decoration + ".";
                return desc;
            }
        }
    }


    class Outside : Location
    {
        public Outside(bool hot, string Name) : base(Name)
        {
            this.hot = hot;
        }
        private readonly bool hot;
        public override string Description
        {
            get
            {
                string desc = "Na " + Name + " jest ";
                desc += (hot) ? "gorąco." : "zimno.";
                return desc;
            }
        }
    }


    interface IHasExteriorDoor
    {
        string DoorDescription { get; }
        Location DoorLocation { get; set; }
    }


    class OutsideWithDoor : OutsideWithHidingPlace, IHasExteriorDoor
    {
        public OutsideWithDoor(bool hot, string Name, string doorDescription, string hideout) : base(hot, Name, hideout)
        {
            this._doorDescription = doorDescription;
            Hideout = hideout;
        }
        private readonly string _doorDescription;
        public string DoorDescription { get { return _doorDescription; } }
        public Location DoorLocation { get; set; }
        public override string Description
        {
            get
            {
                string desc = base.Description;
                desc += " " + Name + " ma " + DoorDescription + ".";
                return desc;
            }
        }

        public string Hideout { get; }
    }

    class RoomWithDoor : RoomWithHidingPlace, IHasExteriorDoor
    {
        public RoomWithDoor(string decoration, string Name, string doorDescription, string hideout) : base(decoration, Name,hideout)
        {
            this._doorDescription = doorDescription;
            Hideout = hideout;
        }
        private readonly string _doorDescription;

        public string DoorDescription { get { return _doorDescription; } }

        public Location DoorLocation { get; set; }
        public override string Description
        {
            get
            {
                string desc = base.Description;
                desc += " " + Name + " ma " + DoorDescription + ".";
                return desc;
            }
        }

        public string Hideout { get; }
    }
    interface IHidingPlace
    {
        public string Hideout { get; }
    }
    class OutsideWithHidingPlace : Outside, IHidingPlace
    {
        public string Hideout
        {
            get;
        }
        public OutsideWithHidingPlace(bool hot, string name, string _hideout) : base(hot, name)
        {
            this.Hideout = _hideout;
        }
    }

    class RoomWithHidingPlace : Room, IHidingPlace
    {
        public string Hideout { get; }
        public RoomWithHidingPlace(string decorations, string name, string _hideout) : base(decorations, name)
        {
            this.Hideout = _hideout;
        }
    }
    class Opponent
    {
        private Location myLocation;
        public Random random;
        public Opponent(Location _startingLocalization)
        {   
            this.myLocation = _startingLocalization;
            random = new Random();
        }
        public void Move()
        {
            do 
            {
                Location location = myLocation.Exits[random.Next(myLocation.Exits.Length)];
                if (location is IHasExteriorDoor)
                {
                    if (random.Next(2) == 1)
                        myLocation = location;
                    else
                        //location = myLocation.Exits[random.Next(myLocation.Exits.Length)];
                        return;
                }
                else
                    myLocation = myLocation.Exits[random.Next(myLocation.Exits.Length)];
                //metoda chodzi dopuki nie znajdzie miejsca które ma miejsce do schowania
            } while (myLocation is IHidingPlace);
           
        }
       public bool Check(Location loc)
        {
            if (loc == this.myLocation)
                return true;
            else
                return false;
        }
    }
}

