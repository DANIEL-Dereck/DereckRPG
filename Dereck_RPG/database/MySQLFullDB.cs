using ClassLibrary2.Entities.Generator;
using WorldOfFantasy.entities;
using WorldOfFantasy.entities.json;
using WorldOfFantasy.logger;
using Faker;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WorldOfFantasy.database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MySQLFullDB : DbContext
    {
        const int genernumber = 10;

        public DbSet<Player> playerTable { get; set; }
        public DbSet<Monster> monsterTable { get; set; }
        public DbSet<Stats> statsTable { get; set; }
        
        Logger logger = new Logger("MySQLFullDB", LogMode.CURRENT_FOLDER, AlertMode.CONSOLE, "MYSQL", true);


        public MySQLFullDB()
            : base(JsonManager.Instance.ReadFile<ConnectionString>(@"..\..\..\jsonconfig\", @"MysqlConfig.json").ToString())
        {
            InitLocalMySQL();
        }

        public void InitLocalMySQL()
        {
            if (this.Database.CreateIfNotExists())
            {
                GenerateMonster();
                this.SaveChangesAsync();

                GeneratePlayer();
                this.SaveChangesAsync();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        #region GenerateDefaultMonster
       public void GenerateMonster()
        {
            for (int i = 0; i < genernumber; i++)
            {
                Monster monster = new Monster();
                monster.Name = "Orc Mal Lecher";
                GenRandomMonster(monster);
                GenStatsMonster(monster);
                monster.MonsterRace = entities.enums.MonsterRace.ORC;
                monsterTable.Add(monster);
            }

            for (int i = 0; i < genernumber; i++)
            {
                Monster monster = new Monster();
                monster.Name = "Gob";
                GenRandomMonster(monster);
                GenStatsMonster(monster);
                monster.MonsterRace = entities.enums.MonsterRace.GOBLIN;
                monsterTable.Add(monster);
            }

            for (int i = 0; i < genernumber; i++)
            {
                Monster monster = new Monster();
                monster.Name = "Tas d'os";
                GenRandomMonster(monster);
                GenStatsMonster(monster);
                monster.MonsterRace = entities.enums.MonsterRace.SQUELETTE;
                monsterTable.Add(monster);
            }

            for (int i = 0; i < genernumber; i++)
            {
                Monster monster = new Monster();
                monster.Name = "Rodeur";
                GenRandomMonster(monster);
                GenStatsMonster(monster);
                monster.MonsterRace = entities.enums.MonsterRace.ZOMBIE;
                monsterTable.Add(monster);
            }
        }

        public void GenStatsMonster(Monster monster)
        {
            Stats stat = new Stats();
            monster.Stats = stat.GenRandomStats();
        }

        public void GenRandomMonster(Monster monster)
        {
            monster.Lvl = RandomNumber(1, 20);
            monster.Vie = RandomNumber((1 * monster.Lvl), (100 * monster.Lvl));
        }

        #endregion



        #region GenerateDefaultPlayer
        public void GeneratePlayer()
        {
            Player player = new Player();
            player.Name = "Zoya";
            GenRandomPlayer(player);
            GenStatsPlayer(player);
            player.Classe = entities.enums.Classe.ARCHER;
            player.Race = entities.enums.Race.ELFE;
            playerTable.Add(player);

            Player player1 = new Player();
            player1.Name = "Conan";
            GenRandomPlayer(player1);
            GenStatsPlayer(player1);
            player1.Classe = entities.enums.Classe.BARBARE;
            player1.Race = entities.enums.Race.NAIN;
            playerTable.Add(player1);

            Player player2 = new Player();
            player2.Name = "Sparadrap";
            GenRandomPlayer(player2);
            GenStatsPlayer(player2);
            player2.Classe = entities.enums.Classe.PRETRE;
            player2.Race = entities.enums.Race.HUMAIN;
            playerTable.Add(player2);

            Player player3 = new Player();
            player3.Name = "Amadeus";
            GenRandomPlayer(player3);
            GenStatsPlayer(player3);
            player3.Classe = entities.enums.Classe.SORCIER;
            player3.Race = entities.enums.Race.LAPOURS;
            playerTable.Add(player3);

            Player player4 = new Player();
            player4.Name = "Pontius";
            GenRandomPlayer(player4);
            GenStatsPlayer(player4);
            player4.Classe = entities.enums.Classe.TEMPLIER;
            player4.Race = entities.enums.Race.PANDICORNE;
            playerTable.Add(player4);

            Player player5 = new Player();
            player5.Name = "Ragnard";
            GenRandomPlayer(player5);
            GenStatsPlayer(player5);
            player5.Classe = entities.enums.Classe.BARBARE;
            player5.Race = entities.enums.Race.HUMAIN;
            playerTable.Add(player5);
        }

        public void GenStatsPlayer(Player player)
        {
            Stats stat = new Stats();
            player.Stats = stat.GenRandomStats();
        }

        public void GenRandomPlayer(Player player)
        {
            player.Lvl = RandomNumber(1,100);
            player.Vie = RandomNumber((10 * player.Lvl), (100 * player.Lvl));
        }
        
        #endregion

        static int RandomNumber(int min, int max)
        {
            return Number.RandomNumber(min, max);
        }

    }
}
