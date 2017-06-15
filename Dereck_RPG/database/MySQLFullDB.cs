using ClassLibrary2.Entities.Generator;
using Dereck_RPG.entities;
using Dereck_RPG.entities.json;
using Dereck_RPG.logger;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Dereck_RPG.database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MySQLFullDB : DbContext
    {
        const int genernumber = 10;

        public DbSet<Player> playerTable { get; set; }
        public DbSet<Monster> monsterTable { get; set; }

        public DbSet<Donjon> donjonTable { get; set; }
        public DbSet<Items> itemsTable { get; set; }
        public DbSet<Planetes> planetesTable { get; set; }
        public DbSet<Regions> regionsTable { get; set; }
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
                EntityGenerator<Planetes> generatorPlanete = new EntityGenerator<Planetes>();
                for (int i = 0; i < genernumber; i++)
                {
                    planetesTable.Add(generatorPlanete.GenerateItem());
                    logger.Log("Initalisation Planete:" + i);
                }

                EntityGenerator<Regions> generatorRegions = new EntityGenerator<Regions>();
                for (int i = 0; i < genernumber; i++)
                {
                    regionsTable.Add(generatorRegions.GenerateItem());
                    logger.Log("Initalisation Regions:" + i);
                }
                this.SaveChangesAsync();

                EntityGenerator<Donjon> generatorDonjon = new EntityGenerator<Donjon>();
                for (int i = 0; i < genernumber; i++)
                {
                    donjonTable.Add(generatorDonjon.GenerateItem());
                    logger.Log("Initalisation Donjon:" + i);
                }

                EntityGenerator<Items> generatorItems = new EntityGenerator<Items>();
                for (int i = 0; i < genernumber; i++)
                {
                    itemsTable.Add(generatorItems.GenerateItem());
                    logger.Log("Initalisation Items:" + i);
                }
                this.SaveChangesAsync();

                EntityGenerator<Stats> generatorStats = new EntityGenerator<Stats>();
                for (int i = 0; i < genernumber; i++)
                {
                    statsTable.Add(generatorStats.GenerateItem());
                    logger.Log("Initalisation Stats:" + i);
                }
                this.SaveChangesAsync();

                EntityGenerator<Monster> generatorMonster = new EntityGenerator<Monster>();
                for (int i = 0; i < genernumber; i++)
                {
                    monsterTable.Add(generatorMonster.GenerateItem());
                    logger.Log("Initalisation Monster:" + i);
                }
                this.SaveChangesAsync();

                EntityGenerator<Player> generatorPlayer = new EntityGenerator<Player>();
                for (int i = 0; i < genernumber; i++)
                {
                    playerTable.Add(generatorPlayer.GenerateItem());
                    logger.Log("Initalisation Player:" + i);
                }
                this.SaveChangesAsync();
            }
        }

        private void generateDefaultPlanete()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }

}
