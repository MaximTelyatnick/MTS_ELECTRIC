using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FirebirdSql.Data.FirebirdClient;
using MTS.DAL.Entities.QueryModels;
using MTS.DAL.Entities.Models;
using System.IO;
using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace MTS.DAL.EF
{
    public static class Connection
    {
        public static string ConnectionString;
    }
    
    public class ERP_Context : DbContext
    {
        

        #region DBSet`s


        //M
        //FOR program MTS
        public DbSet<MTS_AUTHORIZATION_USERS> MTS_AUTHORIZATION_USERS { get; set; }
        public DbSet<MtsAssembliesInfo> MtsAssembliesInfo { get; set; }
        public DbSet<MtsAssembliesCustomerInfo> MtsAssembliesCustomerInfo { get; set; }
      //  public DbSet<MtsDocuments> MtsSpeciications { get; set; }
        public DbSet<MtsSpecificationTreeInfo> MtsSpeciicationTreeInfo { get; set; }
        public DbSet<MtsDetailsInfo> MtsDetailsInfo { get; set; }
        public DbSet<MTS_SPECIFICATIONS> MTSSpecificationsOld { get; set; }
        public DbSet<MTS_CREATED_DETAILS> MTSCreateDetals { get; set; }
        public DbSet<MTS_GOST> MTSGost { get; set; }
        public DbSet<MTS_NOMENCLATURES> MTSNomenclaturesOld { get; set; }
        public DbSet<MTS_GUAGES> MTS_GUAGES { get; set; }
        public DbSet<MTS_DEATAILS_PROCESSING> MTSDetailsProcessing { get; set; }
        public DbSet<MTS_DETAILS> MTS_DETAILS { get; set; }
        public DbSet<MTS_MATERIALS> MTS_MATERIALS { get; set; }
        public DbSet<MTS_MEASURE> MTS_MEASURE { get; set; }
        public DbSet<MTS_PURCHASED_PRODUCTS> MTS_PURCHASED_PRODUCTS { get; set; }
        public DbSet<MTS_NOMENCLATURE_GROUPS> MTS_NOMENCLATURE_GROUPS { get; set; }
        public DbSet<MTS_ADDIT_CALCULATION> MTS_ADDIT_CALCULATION { get; set; }
        public DbSet<UsersInfo> UsersInfo { get; set; }        
        public DbSet<UserDetails> UserDetails { get; set; }
        
        #endregion

        static ERP_Context()
        {
            FbConnectionStringBuilder csb;

            string[] ipDB = File.ReadAllLines("DBSettings/ipDB.txt");
            string[] portDB = File.ReadAllLines(@"DBSettings/portDB.txt");
            string[] aliasDB = File.ReadAllLines(@"DBSettings/aliasDB.txt");
            string[] userDB = File.ReadAllLines(@"DBSettings/userDB.txt");
            string[] passDB = File.ReadAllLines(@"DBSettings/passDB.txt");
            int finalPort = 0;
            try
            {
                string splitPattern = @"[^\d]";
                string[] result = Regex.Split(Convert.ToString(portDB[0]), splitPattern);
                var finalresult = string.Join("", result.Where(e => !String.IsNullOrEmpty(e)));
                finalPort = 0;
                int.TryParse(finalresult, out finalPort);
            }
            catch (Exception ex)
            {
                finalPort = 3050;
            }

            if (finalPort == 0)
                finalPort = 3050;



            csb = new FbConnectionStringBuilder()
            {
                //DataSource = "server-tfs",
                //DataSource = "localhost",
                DataSource = Convert.ToString(ipDB[0]),
                Port = finalPort,
                Database = Convert.ToString(aliasDB[0]),
                UserID = Convert.ToString(userDB[0]),
                Password = Convert.ToString(passDB[0]),
                Charset = "UTF8",
                Pooling = true,
                ConnectionLifeTime = 900
            };


            Connection.ConnectionString = csb.ConnectionString;
            Database.SetInitializer<ERP_Context>(null); 
        }

        public ERP_Context()
            : base(new FbConnection(Connection.ConnectionString), true)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            modelBuilder.Conventions.Add(new DecimalPropertyConvention(15, 6));
        }
    }
}
