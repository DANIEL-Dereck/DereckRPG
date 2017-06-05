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

//        public DbSet<EtreVivant> etreVivantTable { get; set; }
        public DbSet<Player> playerTable { get; set; }
        public DbSet<Monster> monsterTable { get; set; }

        public DbSet<Donjon> donjonTable { get; set; }
        public DbSet<Items> itemsTable { get; set; }
        public DbSet<Planetes> planetesTable { get; set; }
        public DbSet<Position> positionTable { get; set; }
        public DbSet<Regions> regionsTable { get; set; }
        public DbSet<Stats> statsTable { get; set; }
        

        Logger logger = new Logger("MySQLFullDB", LogMode.CURRENT_FOLDER, AlertMode.OVERLAY, "MYSQL", true);


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
                this.SaveChangesAsync();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Chercher TPC EF6 pour crée table Etre vivant + monstre + player
            modelBuilder.Entity<EtreVivant>()
                .Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Player>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Player");
            });

            modelBuilder.Entity<Monster>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Monster");
            });
        }
    }

}
