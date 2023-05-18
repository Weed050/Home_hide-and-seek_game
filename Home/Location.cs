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
           get {
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
        public Room(string decoration,string Name):base(Name)
        {
            this.Decoration = decoration;
        }
        private readonly string Decoration;
        public override string Description
        {
            get { 
                   string desc = " Widzisz tutaj "+Decoration +".";
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
                string desc = " Tutaj jest";
                desc+= (hot) ?  "gorąco." :  " zimno.";
                return desc;
            }
        }
    }


    interface IHasExteriorDoor
    {
        string  DoorDescription { get; }
         Location DoorLocation { get; set; }
    }


    class OutsideWithDoor : Outside, IHasExteriorDoor
    {
        public OutsideWithDoor(bool hot, string Name,string doorDescription) : base(hot,Name)
        {
            this._doorDescription = doorDescription;
        }
        private readonly string _doorDescription;
        public  string DoorDescription { get { return _doorDescription; } }
        public Location DoorLocation { get; set; }
    }

    class RoomWithDoor : Room, IHasExteriorDoor
    {
        public RoomWithDoor(string decoration, string Name, string doorDescription) : base(decoration,Name)
        {
            this._doorDescription = doorDescription;
        }
        private readonly string _doorDescription;

        public string DoorDescription { get { return _doorDescription; } }

        public Location DoorLocation { get; set; }
    }
}
