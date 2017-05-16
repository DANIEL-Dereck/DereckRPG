using ClassLibrary2.Entities.Generator;
using Dereck_RPG.entities;
using Dereck_RPG.entities.json;
using Dereck_RPG.logger;
using System.Data.Entity;

namespace Dereck_RPG.database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MySQLFullDB : DbContext
    {
        const int genernumber = 10;
        public DbSet<Caracteristiques> caracteristiquesTable { get; set; }
        public DbSet<Donjon> donjonTable { get; set; }
        public DbSet<Player> playerTable { get; set; }
        public DbSet<Pnj> pnjTable { get; set; }
        public DbSet<Items> itemsTable { get; set; }
        public DbSet<Monster> monsterTable { get; set; }
        public DbSet<Objectif> objectifTable { get; set; }
        public DbSet<Planetes> planetesTable { get; set; }
        public DbSet<Position> positionTable { get; set; }
        public DbSet<Quest> questTable { get; set; }
        public DbSet<Regions> regionsTable { get; set; }
        public DbSet<Stats> statsTable { get; set; }
//        public DbSet<EtreVivant> etreVivantTable { get; set; }

        Logger logger = new Logger("MySQLFullDB", LogMode.CURRENT_FOLDER, AlertMode.OVERLAY, "MYSQL", true);


        public MySQLFullDB()
            : base(JsonManager.Instance.ReadFile<ConnectionString>(@"..\..\..\jsonconfig\", @"MysqlConfig.json").ToString())
        {
            InitLocalMySQL();
        }

        public object ZooTable { get; private set; }

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
                this.SaveChangesAsync();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }

}
