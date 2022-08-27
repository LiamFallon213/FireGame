using System;
using System.Collections.Generic;
using System.Text;

namespace FireGame {
    class Tile {
        public Tile type {get; set;}
        public int moisture { get; set; }
        public bool burned { get; set; }
        public float heat { get; set; }
        public float fuel { get; set; }

    }
}
