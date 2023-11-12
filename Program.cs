using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Я не уверен, что сделал правильно...

/// <summary>
/// Реализовать: 
//1.Классы
//1.House(Дом), Basement(Фундамент), Walls(Стены), Door(Дверь), Window(Окно), Roof(Крыша);
//2.Team(Бригада строителей), Worker(Строитель), TeamLeader(Бригадир).
//2.Интерфейсы
//1.IWorker, IPart.
/// </summary>
namespace Building_A_House
{
    interface IPart
    {
        bool IsBuilt { get; set; }
    }

    interface IWorker
    {
        void Build(IPart part);
    }

    class House : IPart
    {
        public bool IsBuilt { get; set; }
    }

    class Basement : IPart
    {
        public bool IsBuilt { get; set; }
    }

    class Walls : IPart
    {
        public bool IsBuilt { get; set; }
    }

    class Door : IPart
    {
        public bool IsBuilt { get; set; }
    }

    class Window : IPart
    {
        public bool IsBuilt { get; set; }
    }

    class Roof : IPart
    {
        public bool IsBuilt { get; set; }
    }

    class Worker : IWorker
    {
        public string Name { get; set; }

        public Worker(string name)
        {
            Name = name;
        }

        public void Build(IPart part)
        {
            Console.WriteLine($"{Name} строит {part.GetType().Name}");
            part.IsBuilt = true;
        }
    }

    class TeamLeader : IWorker
    {
        public string Name { get; set; }

        public TeamLeader(string name)
        {
            Name = name;
        }

        public void Build(IPart part)
        {
            Console.WriteLine($"{Name} проверяет {part.GetType().Name}");
        }

        public void Report(List<IPart> parts)
        {
            Console.WriteLine("\nОтчёт:");
            foreach (var part in parts)
            {
                Console.WriteLine($"{part.GetType().Name} построено: {part.IsBuilt}");
            }
        }
    }

    class Team
    {
        public List<IWorker> Workers { get; set; }

        public Team(List<IWorker> workers)
        {
            Workers = workers;
        }

        public void Build(House house)
        {
            foreach (var worker in Workers)
            {
                if (worker is TeamLeader)
                {
                    ((TeamLeader)worker).Report(new List<IPart> { house });
                }
                else
                {
                    worker.Build(house);
                }
            }
        }

        public void Build(Basement basement)
        {
            foreach (var worker in Workers)
            {
                if (worker is TeamLeader)
                {
                    ((TeamLeader)worker).Report(new List<IPart> { basement });
                }
                else
                {
                    worker.Build(basement);
                }
            }
        }

        public void Build(Walls walls)
        {
            foreach (var worker in Workers)
            {
                if (worker is TeamLeader)
                {
                    ((TeamLeader)worker).Report(new List<IPart> { walls });
                }
                else
                {
                    worker.Build(walls);
                }
            }
        }

        public void Build(Door door)
        {
            foreach (var worker in Workers)
            {
                if (worker is TeamLeader)
                {
                    ((TeamLeader)worker).Report(new List<IPart> { door });
                }
                else
                {
                    worker.Build(door);
                }
            }
        }

        public void Build(Window window)
        {
            foreach (var worker in Workers)
            {
                if (worker is TeamLeader)
                {
                    ((TeamLeader)worker).Report(new List<IPart> { window });
                }
                else
                {
                    worker.Build(window);
                }
            }
        }

        public void Build(Roof roof)
        {
            foreach (var worker in Workers)
            {
                if (worker is TeamLeader)
                {
                    ((TeamLeader)worker).Report(new List<IPart> { roof });
                }
                else
                {
                    worker.Build(roof);
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var house = new House();
            var basement = new Basement();
            var walls = new Walls();
            var door = new Door();
            var window = new Window();
            var roof = new Roof();

            var teamLeader = new TeamLeader("Бригадир");
            var workers = new List<IWorker>
            {
                new Worker("Строитель 1"),
                new Worker("Строитель 2"),
                new Worker("Строитель 3"),
                new Worker("Строитель 4"),
                teamLeader
            };

            var team = new Team(workers);

            team.Build(basement);
            team.Build(walls);
            team.Build(door);
            team.Build(window);
            team.Build(window);
            team.Build(window);
            team.Build(window);
            team.Build(roof);
            team.Build(house);

            teamLeader.Report(new List<IPart> { basement, walls, door, window, window, window, window, roof, house });


            Console.WriteLine("Строительство дома завершено: ловите аптечку господин заказчик, выбирайте на свой вкус");
            Console.WriteLine(@"
       _
     _|=|__________
    /              \
   /                \
  /__________________\
   ||  || /--\ ||  ||
   ||[]|| | .| ||[]||
 ()||__||_|__|_||__||()
( )|-|-|-|====|-|-|-|( ) 
^^^^^^^^^^====^^^^^^^^^^^

.
         _
      _-'_'-_
   _-' _____ '-_
_-' ___________ '-_
 |___|||||||||___|
 |___|||||||||___|
 |___|||||||o|___|
 |___|||||||||___|
 |___|||||||||___|
 |___|||||||||___|

.

░░░░╠╩╩╩╣░░░╠╩╩╩╣░░░░
╠╩╩╩╣░█░╚╩╩╩╝░█░╠╩╩╩╣
║░░░║░█░░░░░░░█░║░░░║
║░█░║░░░░░░░░░░░║░█░║
║░█░║░░░░███░░░░║░█░║
║░░░║░░░░███░░░░║░░░║




    ) )        /\
   =====      /  \
  _|___|_____/ __ \____________
 |::::::::::/ |  | \:::::::::::|
 |:::::::::/  ====  \::::::::::|
 |::::::::/__________\:::::::::|
 |_________|  ____  |__________|
  | ______ | / || \ | _______ |
  ||  |   || ====== ||   |   ||
  ||--+---|| |    | ||---+---||
  ||__|___|| |   o| ||___|___||
  |========| |____| |=========|
 (^^-^^^^^-|________|-^^^--^^^)
 (,, , ,, ,/________\,,,, ,, ,)
','',,,,' /__________\,,,',',;;




.



                           ====
                           !!!!
      ==========================
    %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
  %%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
  ||      _____          _____    ||
  ||      | | |          | | |    ||
  ||      |-|-|          |-|-|    ||
  ||      #####          #####    ||
  ||                              ||
  ||      _____   ____   _____    ||
  ||      | | |   @@@@   | | |    ||
  ||      |-|-|   @@@@   |-|-|    ||
  ||      #####   @@*@   #####    ||
  ||              @@@@            ||
******************____****************
**************************************


.


                                      /\
                                      /\
                                      /\
                                      /\
                                    _`=='_
                                 _-~......~-_
                             _--~............~--_
                       __--~~....................~~--__
           .___..---~~~................................~~~---..___,
            `=.________________________________________________,='
               @^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^@
                        |  |  I   I   II   I   I  |  |
                        |  |__I___I___II___I___I__|  |
                        | /___I_  I   II   I  _I___\ |
                        |'_     ~~~~~~~~~~~~~~     _`|
                    __-~...~~~~~--------------~~~~~...~-__
            ___---~~......................................~~---___
.___..---~~~......................................................~~~---..___,
 `=.______________________________________________________________________,='
    @^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^@
              |   |    | |    |  |    ||    |  |    | |    |   |
              |   |____| |____|  |    ||    |  |____| |____|   |
              |__________________|____||____|__________________|
            _-|_____|_____|_____|__|------|__|_____|_____|_____|-_





.





                 _ _
                ( Y )
                 \ /  
                  \          /^\
                    )       //^\\
                 (         //   \\
                   )      //     \\
                  __     //       \\
                 |=^|   //    _    \\
               __|= |__//    (+)    \\
              /LLLLLLL//      ~      \\
             /LLLLLLL//               \\
            /LLLLLLL//                 \\
           /LLLLLLL//  |~[|]~| |~[|]~|  \\
           ^| [|] //   | [|] | | [|] |   \\
            | [|] ^|   |_[|]_| |_[|]_|   |^
         ___|______|                     |
        /LLLLLLLLLL|_____________________|
       /LLLLLLLLLLL/LLLLLLLLLLLLLLLLLLLLLL\
      /LLLLLLLLLLL/LLLLLLLLLLLLLLLLLLLLLLLL\
      ^||^^^^^^^^/LLLLLLLLLLLLLLLLLLLLLLLLLL\
       || |~[|]~|^^||^^^^^^^^^^||^|~[|]~|^||^^
       || | [|] |  ||  |~~~~|  || | [|] | ||
       || |_[|]_|  ||  | [] |  || |_[|]_| ||
       ||__________||  |   o|  ||_________||
     .'||][][][][][||  | [] |  ||[][][][][||.'.
    .'||[][][][][]||_-`----' - _ ||][][][] || .
  .(')^(.)(').()'^@/-- -- - --\@( )'().(( ) ^ (.) ^
'( )^(`)'.(').( )@/-- -- - -- -\@ (.)'(.), ( ).(').





.


             (
                )
            (            ./\.
         |^^^^^^^^^|   ./LLLL\.
         |`.'`.`'`'| ./LLLLLLLL\.
         |.'`'.'`.'|/LLLL/^^\LLLL\.
         |.`.''``./LLLL/^ () ^\LLLL\.
         |.'`.`./LLLL/^  =   = ^\LLLL\.
         |.`../LLLL/^  _.----._  ^\LLLL\.
         |'./LLLL/^ =.' ______ `.  ^\LLLL\.
         |/LLLL/^   /|--.----.--|\ = ^\LLLL\.
       ./LLLL/^  = |=|__|____|__|=|    ^\LLLL\.
     ./LLLL/^=     |*|~~|~~~~|~~|*|   =  ^\LLLL\.
   ./LLLL/^        |=|--|----|--|=|        ^\LLLL\.
 ./LLLL/^      =   `-|__|____|__|-' =        ^\LLLL\.
/LLLL/^   =         `------------'        =    ^\LLLL\
~~|.~       =        =      =          =         ~.|~~
  ||     =      =      = ____     =         =     ||
  ||  =               .-'    '-.        =         ||
  ||     _..._ =    .'  .-()-.  '.  =   _..._  =  ||
  || = .'_____`.   /___:______:___\   .'_____`.   ||
  || .-|---.---|-.   ||  _  _  ||   .-|---.---|-. ||
  || |=|   |   |=|   || | || | ||   |=|   |   |=| ||
  || |=|___|___|=|=  || | || | ||=  |=|___|___|=| ||
  || |=|~~~|~~~|=|   || | || | ||   |=|~~~|~~~|=| ||
  || |*|   |   |*|   || | || | ||  =|*|   |   |*| ||
  || |=|---|---|=| = || | || | ||   |=|---|---|=| ||
  || |=|   |   |=|   || | || | ||   |=|   |   |=| ||
  || `-|___|___|-'   ||o|_||_| ||   `-|___|___|-' ||
  ||  '---------`  = ||  _  _  || =  `---------'  ||
  || =   =           || | || | ||      =     =    ||
  ||  %@&   &@  =    || |_||_| ||  =   @&@   %@ = ||
  || %@&@% @%@&@    _||________||_   &@%&@ %&@&@  ||
  ||,,\\V//\\V//, _|___|------|___|_ ,\\V//\\V//,,||
  |--------------|____/--------\____|--------------|
 /- _  -  _   - _ -  _ - - _ - _ _ - _  _-  - _ - _ \
/____________________________________________________\

           ");
        }
    }
}
