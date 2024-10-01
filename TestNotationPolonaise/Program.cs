using System;
using System.Linq;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }
       
        
        static float Polonaise(String phrase)
        {            
            //sép la formule en élémt ind ds un tableau
            string[] tab = phrase.Split(' ');                  
            int nbCases = tab.Length;                      
           //on vérifie qu'un signe de calcul existe
           for (int k=0; k<nbCases;k++)
            {
                int signe = 0;
                if (tab[k]=="+"||tab[k]=="-" || tab[k] == "*" || tab[k] == "/")
                {
                    signe++;
                }
                else
                {
                    return float.NaN;
                }
            }

            for (int n=(nbCases-1); n>=0; n--)
            {                                              
                //effectuer les calculs selon le type
               if(tab[n]=="+"||tab[n]=="-"||tab[n]=="*"||tab[n]=="/")
                {
                    float resultat = 0, nb1=0, nb2=0;
                    try
                    {
                    nb1 = float.Parse(tab[n + 1]);
                    nb2 = float.Parse(tab[n + 2]);
                    }
                    catch
                    {
                        return float.NaN;
                    }                    
                    switch (tab[n])
                    {
                        case "+":                           
                            resultat = nb1 + nb2;
                            break;
                        case "-":                            
                            resultat = nb1 - nb2;
                            break;
                        case "*":                            
                            resultat = nb1 * nb2;
                            break;
                        case "/":
                            if (nb2 == 0)
                            {
                                return float.NaN;
                            }
                            else
                            {
                                resultat = nb1/nb2;
                            }
                            
                            break;
                    }
                    tab[n] = resultat.ToString();
                    //on décale ces 2 cases des deux chiffres used à la fin du tableau 
                    for (int j = n+1; j <=(nbCases - 3); j++)
                        {
                            tab[j] = tab[j + 2];                           
                        }  
                    //on vide les deux dern cases du tableau
                        tab[nbCases - 1] = " ";
                        tab[nbCases - 2] = " ";    
               }                
                //renvoyer le résultat                
            }  
             return float.Parse(tab[0]);                                  
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                //contrôle saisie             
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
