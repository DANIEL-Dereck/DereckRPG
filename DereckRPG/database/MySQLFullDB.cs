using DereckRPG.entities;
using DereckRPG.entities.json;
using System.Data.Entity;

namespace DereckRPG.database
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MySQLFullDB : DbContext
    {
        public DbSet<Caracteristiques> caracteristiquesTable { get; set; }
        public DbSet<Donjon> donjonTable { get; set; }
        public DbSet<Elements> elementsTable { get; set; }
        public DbSet<EtreVivant> etreVivantTable { get; set; }
        public DbSet<Items> itemsTable { get; set; }
        public DbSet<Monster> monsterTable { get; set; }
        public DbSet<Objectif> objectifTable { get; set; }
        public DbSet<Planetes> planetesTable { get; set; }
        public DbSet<Player> playerTable { get; set; }
        public DbSet<Pnj> pnjTable { get; set; }
        public DbSet<Position> positionTable { get; set; }
        public DbSet<Quest> questTable { get; set; }
        public DbSet<Regions> regionsTable { get; set; }
        public DbSet<Stats> statsTable { get; set; }

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
                /*
                EntityGenerator<Address> generatorAddress = new EntityGenerator<Address>();
                for (int i = 0; i < 10; i++)
                {
                    AddressTable.Add(generatorAddress.GenerateItem());
                }
                */
                this.SaveChangesAsync();
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }

}
