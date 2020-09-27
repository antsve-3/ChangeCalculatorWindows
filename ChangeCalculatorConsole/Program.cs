﻿using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace ChangeCalculatorConsole
{
    class Program
    {
        static void Main()
        {
            //Deklaration av variabler
            //Klassen Denomination används för att skapa upp de valörer som ska användas av programmet.
            //Fördelen med att använda en klass är att man enkelt kan byta ut eller lägga till valörer
            //(t ex 200-lappar, 2-kronor)
            Denomination femhundra = new Denomination("femhundralapp", "femhundralappar", 500);
            Denomination hundra = new Denomination("hundralapp", "hundralappar", 100);
            Denomination femtio = new Denomination("femtiolapp", "femtiolappar", 50);
            Denomination tjugo = new Denomination("tjugolapp", "tjugolappar", 20);
            Denomination tio = new Denomination("tiokrona", "tiokronor", 10);
            Denomination fem = new Denomination("femkrona", "femkronor", 5);
            Denomination en = new Denomination("enkrona", "enkronor", 1);
            int denominatorCount;//håller antalet av den aktuella valören
            String countAndName; //antalet av och namnet (singular eller plural) för den aktuella valören
            //lägger till alla valörer i en array som jag senare kan loopa igenom istället för att behöva 
            //utföra samma moment för och en av valörerna
            Denomination[] denominationsArray = { femhundra, hundra, femtio, tjugo, tio, fem, en };

            int change; // växelsumman

            //Dessa variabler används för en bonus-feature. Genom att lägga koden i en while-loop
            //får användaren valet att starta om med en ny växelberäkning då den första är avslutad.
            bool keepCalculating = true; //Så länge denna variabel är true fortsätter programmet att köras

            //Fortsätter att köra programmet så länge keepCalculating är true
            while (keepCalculating == true)
            {
                //bryter ut växelberäkningen för att göra programmet mer överskådligt.
                //Resultatet tilldelas variabeln change
                change = ReceivePayment();

                // om betalningen matchar priset behöver ingen växel lämnas
                if (change == 0)
                {
                    Console.WriteLine("Jämt belopp betalat, ingen växel behövs");
                }
                else
                {
                    Console.WriteLine("Växel tillbaka:");
                    //loopar igenom arrayen av valörer för inte behöva upprepa återkommande utskrifter och uträkningar.
                    foreach (Denomination denomination in denominationsArray)
                    {
                        //räknar ut och returnerar antalet av den aktuella valören
                        denominatorCount = denomination.SetAndReturnCount(change);
                        //TODO flytta till klassen skapa getter för count och namn
                        if (denominatorCount > 0)
                        {
                            //hämtar antal och namn för aktuell valör
                            countAndName = denomination.GetCountAndName();

                            //skriver ut antal och namn för valören
                            Console.WriteLine(countAndName);

                            //uppdaterar change med kvarvarande belopp
                            change %= denomination.GetAmount();
                        }
                    }
                }

                //Frågar om användaren vill göra en ny växelberäkning
                keepCalculating = RunAgain();
            }

        }

        private static int ReceivePayment()
        {
            //En metod som räknar ut och returnerar växelbeloppet utfrån angivet pris och betalt belopp

            //deklarerar variabler, sätter 0 som utgångsvärde för pris och betalt belopp
            //dessa riskerar annars att bli utan värde i o m att tilldelning sker i try-sats
            int _price = 0, _paid = 0, _change;

            Console.WriteLine("Ange pris:");
            //för att användaren ska få en ny möjlighet att fylla i pris om denne har fyllt i med fel datatyp
            //använder jag en while-loop med vilkoret att priset ska ha ändrats från 0
            while (_price == 0)
            {

                try
                {
                    _price = Convert.ToInt32(Console.ReadLine());
                    //om användaren har angett 0 som pris måste loopen brytas. lägger därför till detta villkor
                    if(_price == 0)
                    {
                        break;
                    }
                }
                //fångar eventuella formatfel och hänvisare användaren att ange ett heltal
                catch (FormatException)
                {
                    Console.WriteLine("Beloppet måste anges som ett heltal. Försök igen:");
                }
            }
            Console.WriteLine("Betalt:");
            //använder samma logik för betalt som för pris
            while (_paid == 0)
            {
                try
                {
                    _paid = Convert.ToInt32(Console.ReadLine());
                    if (_paid == 0)
                    {
                        break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Beloppet måste anges som ett heltal. Försök igen:");
                }
            }
            //räknar ut växelbeloppet
            _change = _paid - _price;

            //hänvisar användaren att ange ett nytt belopp om betalningen understiger priset
            while (_change < 0)
            {
                Console.WriteLine("Betalningen understiger priset. Ange nytt betalt belopp:");
                _paid = Convert.ToInt32(Console.ReadLine());
                _change = _paid - _price;
            }
            //returnerar växelvärdet
            return _change;
        }

        private static bool RunAgain()
        {
            //Metoden frågar användaren om denne vill göra en ny beräkning. Returnerar true om en ny beräkning
            //ska göras och false om användaren vill avsluta

            //deklarerar variabler
            bool _answerGiven = false; //har användaren svarat på om en ny beräkning ska genomföras?
            string _newCalculation = "";//användarens svar på om ny beräkning ska göras (J el N)
            bool _keepCalculating = false;//returvärdet som avgör om användaren vill göra en ny beräkning
            while (_answerGiven == false)
            {
                Console.WriteLine("Vill du göra en ny växelberäkning? (J/N)");
                try
                {
                    //användarens svar fångas i variabeln _newCalculation
                    _newCalculation = Console.ReadLine();
                }
                //fångar eventuella formateringsfel om användaren skulle använt någon annan datatyp än String
                catch (FormatException)
                {
                    Console.WriteLine("Svara med J för Ja eller N för Nej");
                }
                //om användaren svarar ja ställs _answerGiven om till true, så att loopen avslutas och 
                //_keepCalculating till true så att en ny beräkning kan genomföras
                if (_newCalculation == "J" || _newCalculation == "j")
                {
                    _answerGiven = true;
                    _keepCalculating = true;
                }
                //om användaren svarar ja ställs _answerGiven om till true, så att loopen avslutas och 
                //_keepCalculating till false så programmet avslutas
                else if (_newCalculation == "N" || _newCalculation == "n")
                {
                    _answerGiven = true;
                    _keepCalculating = false;
                }
                //om användaren svarat något annat uppges denne ange ett korrekt alternativ
                else
                {
                    Console.WriteLine("Svara med J för Ja eller N för Nej");
                }
            }
            return _keepCalculating;
        }
    }
}
