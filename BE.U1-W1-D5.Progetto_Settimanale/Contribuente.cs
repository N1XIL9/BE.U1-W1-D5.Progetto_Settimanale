using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BE.U1_W1_D5.Progetto_Settimanale
{
    internal class Contribuente
    {
        private static string _nome;
        public static string Nome

        {
            get { return _nome; }
            set { _nome = value; }
        }

        private static DateTime _dataNascita;
        public static DateTime DataNascita

        {
            get { return _dataNascita; }
            set { _dataNascita = value; }
        }

        private static string _comuneResidenza;
        public static string ComnuneResidenza

        {
            get { return _comuneResidenza; }
            set { _comuneResidenza = value; }
        }

        private static string _sesso;
        public static string Sesso

        {
            get { return _sesso; }
            set { _sesso = value; }
        }

        private static string _codiceFiscale;

        public static string CodiceFiscale

        {
            get { return _codiceFiscale; }
            set { _codiceFiscale = value; }
        }

        private static double _redditoAnnuale;

        public static double RedditoAnnuale

        {
            get { return _redditoAnnuale; }
            set { _redditoAnnuale = value; }
        }

        private static double _imposta;

        public static double Imposta

        {
            get { return _imposta; }
            set { _imposta = value; }
        }

        private static string _exit;
        public static string Exit

        {
            get { return _exit; }
            set { _exit = value; }
        }



        public static void consoleApplication()

        {

            Console.WriteLine("");
            Console.WriteLine("=============================================================================");
            Console.WriteLine("======= C A L C O L O  D E L L' I M P O S T A  D A  V E R S A R E ===========");
            Console.WriteLine("=============================================================================");
            Console.WriteLine("");

            Console.WriteLine("NOME CONTRIBUENTE:");
            _nome = Console.ReadLine();

            try
            {
                Console.WriteLine("NATO IL (GG/MM/AAAA):");
                _dataNascita = DateTime.Parse(Console.ReadLine());

            sex:
                Console.WriteLine("SESSO M/F:");
                string sex = Console.ReadLine();
                while (sex != "M" && sex != "F")
                {
                    Console.WriteLine("");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("----------- ATTENZIONE! HAI INSERITO UN PARAMETRO NON VALIDO --------");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("");
                                     
                    goto sex;
                }


                Console.WriteLine("RESIDENTE:");
                _comuneResidenza = Console.ReadLine();

                Console.WriteLine("CODICE FISCALE:");
                _codiceFiscale = Console.ReadLine();


                Console.WriteLine("");
                Console.WriteLine("REDDITO ANNUALE");
                _redditoAnnuale = double.Parse(Console.ReadLine());

                Console.OutputEncoding = System.Text.Encoding.UTF8;

                calcoloImposta();
            }
            catch (Exception)

            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("----------- ATTENZIONE! HAI INSERITO UN PARAMETRO NON VALIDO ------------");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("");

                consoleApplication();
            }
        }

        public static void calcoloImposta()
        {

            if (_redditoAnnuale <= 15000)
            {
                Imposta = _redditoAnnuale * 23 / 100;
            }
            else if (_redditoAnnuale >= 15001 && _redditoAnnuale <= 28000)
            {
                Imposta = (_redditoAnnuale - 15000) * 27 / 100 + 3450;
            }
            else if (_redditoAnnuale >= 28001 && _redditoAnnuale <= 55000)
            {
                Imposta = (_redditoAnnuale - 28000) * 38 / 100 + 6960;
            }
            else if (_redditoAnnuale >= 55001 && _redditoAnnuale <= 75000)
            {
                Imposta = (_redditoAnnuale - 55000) * 41 / 100 + 17220;
            }
            else if (_redditoAnnuale > 75001)
            {
                Imposta = (_redditoAnnuale - 75000) * 43 / 100 + 25420;
            }


            Console.WriteLine("");
            Console.WriteLine("========================== R I E P I L O G O ================================");
            Console.WriteLine("");

            Console.WriteLine($"NOME CONTRINUENTE : {_nome}");
            Console.WriteLine($"NATO Il: {_dataNascita.ToString("dd/MM/yyyy")}, {_sesso}");
            Console.WriteLine($"RESIDENTE A: {_comuneResidenza} ");
            Console.WriteLine($"CODICE FISCALE: {_codiceFiscale} ");
            Console.WriteLine("");
            Console.WriteLine($"REDDITO DICHIARATO: € {_redditoAnnuale.ToString("N")}");
            Console.WriteLine("");

            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine($"---------     IMPOSTA DA VERSARE: € {Imposta.ToString("N")}    ------------ ");
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("");

            Console.WriteLine("------------------ VUOI CALCOLARE UNA NUOVA IMPOSTA? Y/N --------------------");

        back:
            string x = Console.ReadLine();

            if (x == "Y" || x == "y")
            {
                consoleApplication();
            }
            else if (x == "N" || x == "n")
            {
                Console.WriteLine("============= D I S C O N N E S S I O N E  IN  C O R S O. . . ===========");
                Thread.Sleep(2000);

                Environment.Exit(0);
            }
            else if (x != "Y" || x != "y" && x != "N" || x != "n")
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("----------- ATTENZIONE! HAI INSERITO UN PARAMETRO NON VALIDO --------------");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("");
                Console.WriteLine("------------------ VUOI CALCOLARE UNA NUOVA IMPOSTA? Y/N ------------------");
                goto back;
            }
        }
    }
}
