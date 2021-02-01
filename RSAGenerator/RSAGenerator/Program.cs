using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace RSAGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool willContinue = true;
            while (willContinue)
            {
                Console.WriteLine("Enter to select function:");
                Console.WriteLine("1. Gernate Private/Public RSA256 Key Pair");
                Console.WriteLine("2. Gernate Public Key from PrivateKey, Path of PrivateKey?:");
                Console.WriteLine("9. Exit");

                int menu;
                int.TryParse(Console.ReadLine(), out menu);

                switch (menu)
                {
                    case 1:
                        string fullPath = Path.GetFullPath(@"\ResultFolder\") + $"{DateTime.Today:dd-MM-yyyy}";
                        CreateFolderNotExist(fullPath);
                        string resultFile1 = fullPath + "\\" + $"{Guid.NewGuid()}-{DateTime.Now:dd-MM-yyyy}";
                        string publicKey1 = "";
                        string privateKey = "";
                        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
                        {
                            try
                            {
                                rsa.ass
                                privateKey = rsa.ToXmlString(true);
                                publicKey1 = rsa.ToXmlString(false);
                            }
                            finally
                            {
                                rsa.PersistKeyInCsp = false;
                            }
                        }
                        using (StreamWriter file = new StreamWriter(resultFile1 + "-private.perm"))
                        {
                            file.WriteLine(privateKey);
                        }

                        using (StreamWriter file = new StreamWriter(resultFile1 + "-public.perm"))
                        {
                            file.WriteLine(publicKey1);
                        }

                        break;

                    case 2:
                        string pathPrivateKey = Console.ReadLine();
                        string privateKey2 = File.ReadAllText(pathPrivateKey);
                        string fullPath2 = Path.GetFullPath(@"\ResultFolder") + "\\" + $"{DateTime.Today:dd-MM-yyyy}";
                        CreateFolderNotExist(fullPath2);
                        string resultFilePublic = fullPath2 + "\\" + $"{Guid.NewGuid()}-{DateTime.Now:dd-MM-yyyy-hh-mm-ss}-public.perm";
                        string publicKey2 = "";
                        using (StreamWriter file = new StreamWriter(resultFilePublic))
                        {
                            file.WriteLine(publicKey2);
                        }

                        break;
                    default:
                        willContinue = false;
                        break;
                }
            }
        }

        private static void CreateFolderNotExist(string fullPath)
        {
            bool exists = Directory.Exists(fullPath);
            if (!exists)
                Directory.CreateDirectory(fullPath);
        }
    }
}
