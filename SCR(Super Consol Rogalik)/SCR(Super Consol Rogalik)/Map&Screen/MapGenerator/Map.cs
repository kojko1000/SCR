using DegeneratorForMaps.MapGenerator.Structures;

namespace DegeneratorForMaps.MapGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class Map
    {
        public int load=0;
        public int loadmax=1;
        public int procent = 0;
        public char[,] GameField { get; init; }
        public int Width { get; init; }
        public int Height { get; init; }
        public int LakesCount { get; init; }
        private int mountainWidth;
        private int mountainHeight;

        private int lakesWidth;
        private int lakesHeight;
        private List<(int y, int x)> mountainChunks = new();
        private List<(int y, int x)> waterChunks = new();


        public void PlaceStructure(int x, int y, char[,] structure)
        {
            if (x < 0 || y < 0)
            {
                Console.WriteLine("aaa");
                return;
            }
            if (x >= Height || y >= Width)
            {
                Console.WriteLine("bbb");
                return;
            }

            for (int i = 0; i < structure.GetLength(0); i++)
            {
                for (int j = 0; j < structure.GetLength(1); j++)
                {
                    if (i + y < Height && j + x < Width)
                    {
                        GameField[i + y, j + x] = structure[i, j];
                    }
                }
            }
        }
        public void PlaceStructure(int x, int y, Structure structure)
        {
            PlaceStructure(x, y, structure.StructureField);
        }
        public Map(int width, int height, int chunkWidth, int ChunkHeight, int lakeWdth, int lakeHeight, int lakeCount)
        {
            Console.CursorVisible = false;
            GameField = new char[height, width];
            Width = width;
            Height = height;

            mountainWidth = chunkWidth;
            mountainHeight = ChunkHeight;

            lakesWidth = lakeWdth;
            lakesHeight = lakeHeight;

            LakesCount = lakeCount;


            GenerateChunks();
            CalculateAndDraw();
            Console.Clear();
        }
        public Map(int width, int height) : this(width, height, width / 6, height / 6, width / 6, height / 6, 5) { }
        public Map() : this(300, 100) { }
        public Map(int width, int height, int lakesCount) : this(width, height, width / 6, height / 6, width / 6, height / 6, lakesCount) { }
        private void GenerateChunks()
        {
            loadmax = Height * Width;
            procent = loadmax / 100;
            string Stringload = "";
            int step = 1;
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    load++ ;
                    if (i == 0 && j == 0)
                    {
                        mountainChunks.Add((i, j));
                        waterChunks.Add((i, j));
                    }

                    (int y, int x) lastMountainChunk = mountainChunks[mountainChunks.Count - 1];
                    (int y, int x) lastLakeChunk = waterChunks[waterChunks.Count - 1];
                    if (i - lastMountainChunk.y >= mountainHeight | j - lastMountainChunk.x >= mountainWidth)
                    {
                        mountainChunks.Add((i, j));
                    }
                    if (i - lastLakeChunk.y >= lakesWidth | j - lastLakeChunk.x >= lakesHeight)
                    {
                        waterChunks.Add((i, j));
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Генерация карты");
                    Console.SetCursorPosition(0, 1);
                    Console.WriteLine("|");
                    Console.SetCursorPosition(26,1);
                    Console.WriteLine("|");
                    if (load*10000/loadmax >= procent * step)
                    {
                        Console.SetCursorPosition(1, 1);
                        Stringload += "/";
                        Console.WriteLine(Stringload+'\n'+ load*100/loadmax+"%");//!!!!!!!!!!!!!!!!!!!!
                        step++;
                        
                    }
                    

                }
            }
        }
        private char[,]? MergeLayers(List<char[,]> layers)
        {
            char[,] buff = layers.ElementAt(0);
            layers.Remove(buff);
            foreach (var layer in layers)
            {
                if (layer.Length != buff.Length)
                {
                    Console.WriteLine("бляблябляблябля");
                    return null;
                }
                for (int i = 0; i < buff.GetLength(0); i++)
                {
                    for (int j = 0; j < buff.GetLength(1); j++)
                    {
                        if (layer[i, j] != Structure.DefaultBlock && layer[i, j] != '\0')
                        {
                            buff[i, j] = layer[i, j];
                        }
                    }
                }
            }

            return buff;
        }

        private void MergeWithMainLayer(char[,] layer)
        {
            if (layer.Length != layer.Length)
            {
                Console.WriteLine("да иди ты нахуй");
                return;
            }
            for (int i = 0; i < layer.GetLength(0); i++)
            {
                for (int j = 0; j < layer.GetLength(1); j++)
                {
                    if (GameField[i, j] == '\0' || layer[i, j] != Structure.DefaultBlock)
                    {
                        GameField[i, j] = layer[i, j];
                    }
                }
            }



        }
        private void CalculateAndDraw()
        {
            List<Structure> structures = new();
            List<char[,]> generatedlayers = new();

            char[,] buff = new char[Height, Width];
            foreach (var i in mountainChunks)
            {
                structures.Add(new Mountains(mountainWidth, mountainHeight, i.x, i.y, 10));
            }
            int lakes = 0;
            while (lakes <= LakesCount)
            {
                var lake = waterChunks.ElementAt(Random.Shared.Next(waterChunks.Count));
                waterChunks.Remove(lake);
                structures.Add(new Lakes(lakesWidth, lakesHeight, lake.x, lake.y));
                lakes++;
            }
            //foreach (var i in waterChunks)
            //{
            //    structures.Add(new Lakes(lakesWidth, lakesHeight, , i.y, 10));
            //}
            foreach (var someStruct in structures)
            {
                for (int i = 0; i < someStruct.Height; i++)
                {
                    for (int j = 0; j < someStruct.Width; j++)
                    {
                        if (someStruct.YOffset + i < Height && someStruct.XOffset + j < Width)
                        {
                            buff[someStruct.YOffset + i, someStruct.XOffset + j] = someStruct.StructureField[i, j];
                        }
                    }
                }
                MergeWithMainLayer(buff);

            }

        }
        public void DebugShowChunks()
        {
            foreach (var i in mountainChunks)
            {
                Console.WriteLine(i);
            }
        }
        public static void DebugDrawMap(Map map)
        {
            DebugDrawMap(map.GameField);
        }
        public static void DebugDrawMap(char[,] map)
        {
            string str = "";
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    str += map[i, j];
                }
                str += "\n";
            }
            Console.WriteLine(str);
        }

    }
}
