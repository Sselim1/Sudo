namespace Sudo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sudo = new int[][]
             {
                [ 5, 3, 0, 0, 7, 0, 0, 0, 0 ],
                [ 6, 0, 0, 1, 9, 5, 0, 0, 0 ],
                [ 0, 9, 8, 0, 0, 0, 0, 6, 0 ],
                [ 8, 0, 0, 0, 6, 0, 0, 0, 3 ],
                [ 4, 0, 0, 8, 0, 3, 0, 0, 1 ],
                [ 7, 0, 0, 0, 2, 0, 0, 0, 6 ],
                [ 0, 6, 0, 0, 0, 0, 2, 8, 0 ],
                [ 0, 0, 0, 4, 1, 9, 0, 0, 5 ],
                [ 0, 0, 0, 0, 8, 0, 0, 7, 9 ]
             };

            fillsudo(sudo);
            for (int i = 0; i < sudo.Length; i++)
            {
                for (int j = 0; j < sudo.Length; j++)
                {
                    Console.Write(sudo[i][j] + " ");
                }
                Console.WriteLine();
            }

        }

        static bool fillsudo(int[][] sudo)
        {
            for (int i = 0; i < sudo.Length; i++)
            {
                for (int j = 0; j < sudo.Length; j++)
                {
                    if (sudo[i][j] == 0)
                    {
                        for (int numofvalid = 1; numofvalid < 10; numofvalid++)
                        {
                            sudo[i][j] = numofvalid;
                            bool isvalid = CheckRow(sudo);
                            if (isvalid)
                                isvalid = Checkcol(sudo);
                            if (isvalid)
                            {
                                isvalid = CheckSub(sudo);
                                if (isvalid)
                                {
                                    if (fillsudo(sudo))
                                    {
                                        return true;
                                    }

                                    sudo[i][j] = 0;
                                }
                                else sudo[i][j] = 0;

                            }
                            else sudo[i][j] = 0;
                        }
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool CheckRow(int[][] sudo)
        {
            var numberInSudo = new List<int>();
            for (int i = 0; i < sudo[0].Length; i++)
            {
                for (int j = 0; j < sudo[0].Length; j++)
                {
                    if (sudo[i][j] != 0)
                    {
                        if (!numberInSudo.Contains(sudo[i][j]))
                        {
                            numberInSudo.Add(sudo[i][j]);
                        }
                        else
                        {
                            return false;

                        }
                    }

                }
                numberInSudo = new List<int>();
            }
            return true;
        }
        public static bool Checkcol(int[][] sudo)
        {
            var numberInSudo = new List<int>();
            for (int i = 0; i < sudo[0].Length; i++)
            {
                for (int j = 0; j < sudo[0].Length; j++)
                {
                    if (sudo[j][i] != 0)
                    {
                        if (!numberInSudo.Contains(sudo[j][i]))
                        {
                            numberInSudo.Add(sudo[j][i]);
                        }
                        else
                        {
                            return false;

                        }
                    }

                }
                numberInSudo = new List<int>();
            }
            return true;
        }
        public static bool CheckSub(int[][] sudo)
        {
            for (int i = 0; i < sudo[0].Length; i += 3)
            {
                for (int j = 0; j < sudo[0].Length; j += 3)
                {
                    var numberOfSubSudo = new List<int>();
                    for (int indexofsubrow = i; indexofsubrow < i + 3; indexofsubrow++)
                    {
                        for (int indexofsubcol = j; indexofsubcol < j + 3; indexofsubcol++)
                        {
                            numberOfSubSudo.Add(sudo[indexofsubrow][indexofsubcol]);
                        }
                    }
                    var numberInSudo = new List<int>();
                    for (int iR = 0; iR < numberOfSubSudo.Count; iR++)
                    {

                        if (numberOfSubSudo[iR] != 0)
                        {
                            if (!numberInSudo.Contains(numberOfSubSudo[iR]))
                            {
                                numberInSudo.Add(numberOfSubSudo[iR]);
                            }
                            else
                            {
                                return false;
                            }
                        }

                    }

                }
            }
            return true;
        }
    }
}