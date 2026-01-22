namespace BridgeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int bridgeLength;
            string bridgeType;
            bool bridgeIsFlat;
            
            try
            {
                if (args.Length > 0)
                {
                    bridgeLength = int.Parse(args[0]);
                    bridgeType = args[1];
                    bridgeIsFlat = bool.Parse(args[2]);
                }
                else
                {
                    bridgeLength = 23;
                    bridgeType = "Stone";
                    bridgeIsFlat = true;
                }
                
                Console.WriteLine(GenerateBridge(bridgeLength, bridgeType, bridgeIsFlat));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static string GenerateBridge(int length, string bridgeType, bool isFlat)
        {
            List<string> bridgeStructure = new List<string>();
            if (length == 1 && !isFlat)
            {
                throw new ArithmeticException("[ERROR] An arched bridge must be longer than 1 tiles long");
            }
            else if (length > 38)
            {
                throw new ArithmeticException("[ERROR] Bridges can't be longer than 38 tiles");
            }
            else if (length < 1)
            {
                throw new ArithmeticException("[ERROR] Bridges can't be 0 or negative tiles long");
            }

            if (bridgeType == "Rope")
            {
                bridgeStructure = RopeBridgeStructure(length);
            }
            else if (bridgeType == "Stone")
            {
                switch (isFlat)
                {
                    case true:
                        bridgeStructure = FlatStoneBridgeStructure(length);
                        break;
                    case false:
                        bridgeStructure = ArchedStoneBridgeStructure(length);
                        break;
                }
            }
            else if (bridgeType == "Wood")
            {
                switch (isFlat)
                {
                    case true:
                        bridgeStructure = FlatWoodBridgeStructure(length);
                        break;
                    case false:
                        bridgeStructure = ArchedWoodBridgeStructure(length);
                        break;
                }
            }
            
            return string.Join(", ", bridgeStructure);
        }

        static List<string> RopeBridgeStructure(int length)
        {
            List<string> bridgeStructure = new List<string>();

            if (length == 1)
            {
                bridgeStructure.AddRange(["DoubleAbutment"]);
            }
            else
            {
                bridgeStructure.AddRange(["AbutmentL"]);

                for (int bridgeLength = length; bridgeLength > 1;)
                {
                    bridgeStructure.AddRange(["Crown"]);
                    bridgeLength -= 1;
                }
                
                bridgeStructure.AddRange(["AbutmentR"]);
            }
            return bridgeStructure;
        }
        
        static List<string> FlatStoneBridgeStructure(int length)
        {
            List<string> bridgeStructure = new List<string>();

            for (int bridgeLength = length; bridgeLength > 0;)
            {
                if (bridgeLength - 5 >= 2 || bridgeLength - 5 == 0)
                {
                    bridgeStructure.AddRange(["AbutmentL", "BracingL", "Crown", "BracingR", "AbutmentR"]);
                    bridgeLength -= 5;
                }
                else if (bridgeLength - 4 >= 2 || bridgeLength - 4 == 0)
                {
                    bridgeStructure.AddRange(["AbutmentL", "BracingL", "BracingR", "AbutmentR"]);
                    bridgeLength -= 4;
                }
                else if (bridgeLength - 3 >= 2 || bridgeLength - 3 == 0)
                {
                    bridgeStructure.AddRange(["AbutmentL", "DoubleBracing", "AbutmentR"]);
                    bridgeLength -= 3;
                }
                else if (bridgeLength - 2 >= 2 || bridgeLength - 2 == 0)
                {
                    bridgeStructure.AddRange(["AbutmentL", "AbutmentR"]);
                    bridgeLength -= 2;
                }
                else if (bridgeLength - 1 >= 2 || bridgeLength - 1 == 0)
                {
                    bridgeStructure.AddRange(["DoubleAbutment"]);
                    bridgeLength -= 1;
                }
                else
                {
                    bridgeLength = 0;
                }

                if (bridgeLength > 0)
                {
                    bridgeStructure.Add("Support");
                    bridgeLength -= 1;
                }
            }

            return bridgeStructure;
        }

        static List<string> ArchedStoneBridgeStructure(int length)
        {
            List<string> bridgeStructure = new List<string>();
            
            if (length == 2)
            {
                bridgeStructure.AddRange(["AbutmentL", "AbutmentR"]);
            }
            else if (length == 3)
            {
                bridgeStructure.AddRange(["AbutmentL", "DoubleBracing", "AbutmentR"]);
            }
            else if (length == 4)
            {
                bridgeStructure.AddRange(["AbutmentL", "BracingL", "BracingR", "AbutmentR"]);
            }
            else if (length > 4 && length < 9)
            {
                bridgeStructure.AddRange(["AbutmentL", "BracingL"]);
                for (int bridgeLength = length - 4; bridgeLength > 0;)
                {
                    bridgeStructure.AddRange(["Crown"]);
                    bridgeLength -= 1;
                }
                bridgeStructure.AddRange(["BracingR", "AbutmentR"]);
            }
            else if (length > 9)
            {
                bridgeStructure.AddRange(["DoubleAbutment", "Support", "AbutmentL", "BracingL"]);
                for (int bridgeLength = length - 8; bridgeLength > 0;)
                {
                    bridgeStructure.AddRange(["Crown"]);
                    bridgeLength -= 1;
                }
                bridgeStructure.AddRange(["BracingR", "AbutmentR", "Support", "DoubleAbutment"]);
            }
            
            return bridgeStructure;
        }

        static List<string> FlatWoodBridgeStructure(int length)
        {
            List<string> bridgeStructure = new List<string>();

            for (int bridgeLength = length; length > 0;)
            {
                if (bridgeLength - 5 >= 3 || length - 5 == 0)
                {
                    bridgeStructure.AddRange(["AbutmentL", "Crown", "Crown", "Crown", "AbutmentR"]);
                    bridgeLength -= 5;
                }
                else if (bridgeLength - 4 >= 3 || length - 4 == 0)
                {
                    bridgeStructure.AddRange(["AbutmentL", "Crown", "Crown", "AbutmentR"]);
                    bridgeLength -= 4;
                }
                else if (bridgeLength - 3 >= 2 || length - 3 == 0)
                {
                    bridgeStructure.AddRange(["AbutmentL", "Crown", "AbutmentR"]);
                    bridgeLength -= 3;
                }
                else if (bridgeLength - 2 >= 2 || length - 2 == 0)
                {
                    bridgeStructure.AddRange(["AbutmentL", "AbutmentR"]);
                    bridgeLength -= 2;
                }

                if (bridgeLength > 0)
                {
                    bridgeStructure.Add("Support");
                    bridgeLength -= 1;
                }
            }

            return bridgeStructure;
        }

        static List<string> ArchedWoodBridgeStructure(int length)
        {
            List<string> bridgeStructure = new List<string>();
            return bridgeStructure;
        }
    }
}