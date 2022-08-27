using System;
using System.Collections.Generic;
using System.Text;

namespace FireGame {
    public class GUI {
       private static int[] dimentions = new int[2];
       public static char[,] screen = new char[,]{ };
       public GUI() { // Gets dimentions from the user
            Console.WriteLine("Input X Dimention: x,y ");
            string[] dimentionsStr = Console.ReadLine().Split(',');
            dimentions[0] = int.Parse(dimentionsStr[0]);
            dimentions[1] = int.Parse(dimentionsStr[1]);
            build();
            draw();
            simulate();
        }
        public static void draw() {
            Console.Clear();
            for (int i = 0; i < dimentions[1]; i++) { // loops outputting the char
                Console.WriteLine("");
                for (int j = 0; j < dimentions[0]; j++) {
                    Console.Write(screen[j,i]);
                }
            }
        }

        private static void build() {
            screen = new char[dimentions[0], dimentions[1]];
            Console.WriteLine("Input coordanates for start of fire: x,y ");
            string[] fireCordStr = Console.ReadLine().Split(',');
           int fireX = int.Parse(fireCordStr[0]);
           int fireY = int.Parse(fireCordStr[1]);
            char charBuffer = 'T';
            for (int i = 0; i < dimentions[1]; i++) { // loops outputting the char
                for (int j = 0; j < dimentions[0]; j++) {
                    screen[j,i] = charBuffer;
                }
            }
            screen[fireX-1, fireY-1] = 'X';
        }

        private static void simulate() {
            char[,] screenBuffer = new char[dimentions[0], dimentions[1]]; ;

            placeBlock(screen);

            for (int i = 0; i < dimentions[1]-1; i++) { // loops outputting the char
                for (int j = 0; j < dimentions[0]-1; j++) {
                    screenBuffer[j, i] = screen[j, i];
                }
            }
            
            Random rng = new Random();
            for (int i = 0; i < dimentions[1]; i++) { // loops outputting the char
                for (int j = 0; j < dimentions[0]; j++) {
                    if(screen[j, i] == 'X') {
                        for (int k = 0; k < 4; k++) {
                            if (rng.Next(0, 100) < 26) {
                                if (j != 0 && screenBuffer[j - 1, i] != 'B') screenBuffer[j - 1, i] = 'X';
                            }
                            if (rng.Next(0, 100) < 26) {
                                if(i!=dimentions[1]-2 && screenBuffer[j, i + 1] != 'B') screenBuffer[j, i+1] = 'X';
                            }
                            if (rng.Next(0, 100) < 26) {
                                if (j != dimentions[0] - 2 && screenBuffer[j+1, i] != 'B') screenBuffer[j+1, i] = 'X';
                            }
                            if (rng.Next(0, 100) < 26) {
                                if (i != 0 && screenBuffer[j , i-1] != 'B') screenBuffer[j, i-1] = 'X';
                            }
                        }
                    }
                }
            }
            screen = screenBuffer;
            draw();
            simulate();
        }

        private static void placeBlock(char[,] screen) {
            Console.WriteLine("Input coordanates for fire block: x,y ");
            string[] blockCordStr = Console.ReadLine().Split(',');
            if (blockCordStr[0] != "") { 
                int blockX = int.Parse(blockCordStr[0])-1;
                int blockY = int.Parse(blockCordStr[1])-1;
                screen[blockX, blockY] = 'B';
            }
        }
    }
}
