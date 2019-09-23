using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace weeklyreport
{
    public partial class Historical : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=ensur; User ID=dcs_user; Password=ensurDCS0!; Persist Security Info=True; Min Pool Size=1; Max Pool Size=1000");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                con.Open();
                SqlCommand com = new SqlCommand("select distinct clientname from t_reporthistory order by clientname", con); // table name 
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset
                DropDownListClients.DataTextField = ds.Tables[0].Columns["ClientName"].ToString(); // text field name of table dispalyed in dropdown
                DropDownListClients.DataValueField = ds.Tables[0].Columns["ClientName"].ToString();             // to retrive specific  textfield name 
                DropDownListClients.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
                DropDownListClients.DataBind();  //binding dropdownlist
                con.Close();

                con.Open();
                com = new SqlCommand("select distinct [timestamp] from t_reporthistory order by [timestamp] desc", con); // table name 
                 da = new SqlDataAdapter(com);
                 ds = new DataSet();
                da.Fill(ds);  // fill dataset
                DropDownListDate.DataTextField = ds.Tables[0].Columns["TimeStamp"].ToString(); // text field name of table dispalyed in dropdown
                DropDownListDate.DataValueField = ds.Tables[0].Columns["TimeStamp"].ToString();             // to retrive specific  textfield name 
                DropDownListDate.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist
                DropDownListDate.DataBind();  //binding dropdownlist
                con.Close();


                //1Top10 MP content
                con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=ensur; User ID=dcs_user; Password=ensurDCS0!; Persist Security Info=True; Min Pool Size=1; Max Pool Size=1000");
                SqlCommand cmd = new SqlCommand("", con);
                con.Open();
                cmd = new SqlCommand("select Field1 as ContentType, Field2 as Documents, Field3 as AvgDocsCreatedPerDay from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'Top10MostActiveContentTypes' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                Top10MostActiveContentTypes.DataSource = rdr;
                Top10MostActiveContentTypes.DataBind();
                con.Close();

                //2Top10 Users Most Logins
                con.Open();
                cmd = new SqlCommand("select Field1 as UserName, Field2 as LoginCount, Field3 as DocsTouchedPerDay from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'Top10UsersMostLogins' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                Top10UsersMostLogins.DataSource = rdr;
                Top10UsersMostLogins.DataBind();
                con.Close();

                //3Top10 Content Creators
                con.Open();
                cmd = new SqlCommand("select Field1 as UserName, Field2 as UserStatus, Field3 as DocsCreated from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'Top10ContentCreators' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                Top10ContentCreators.DataSource = rdr;
                Top10ContentCreators.DataBind();
                con.Close();

                //4top10MostPopularContent
                con.Open();
                cmd = new SqlCommand("select Field1 as ContentType, Field2 as Documents, Field3 as AvgDocsCreatedDaily from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'top10MostPopularContentTypes' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                top10MostPopularContentTypes.DataSource = rdr;
                top10MostPopularContentTypes.DataBind();
                con.Close();

                //5BusiestTimes
                con.Open();
                cmd = new SqlCommand("select Field1 as HR, Field2 as Transactions from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'BusiestTimes' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                BusiestTimes.DataSource = rdr;
                BusiestTimes.DataBind();
                con.Close();

                //6Slowest
                con.Open();
                cmd = new SqlCommand("select Field1 as HR, Field2 as Transactions from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'TopSlowestTimes' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                TopSlowestTimes.DataSource = rdr;
                TopSlowestTimes.DataBind();
                con.Close();

                //7UsersandLastLogin
                con.Open();
                cmd = new SqlCommand("select Field1 as [User], Field2 as LastLoginDate from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'UsersandLastLogin' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                UsersandLastLogin.DataSource = rdr;
                UsersandLastLogin.DataBind();
                con.Close();

                //8AvgNumUsersDuringBusinessHoursByYear
                con.Open();
                cmd = new SqlCommand("select Field1 as [Year], Field2 as AvgUsers from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'AvgNumUsersDuringBusinessHoursByYear' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                AvgNumUsersDuringBusinessHoursByYear.DataSource = rdr;
                AvgNumUsersDuringBusinessHoursByYear.DataBind();
                con.Close();

                //9AvgNumUsersDuringBusinessHoursByMonth
                con.Open();
                cmd = new SqlCommand("select Field1 as [Month], Field2 as AvgUsers from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'AvgNumUsersDuringBusinessHoursByMonth' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                AvgNumUsersDuringBusinessHoursByMonth.DataSource = rdr;
                AvgNumUsersDuringBusinessHoursByMonth.DataBind();
                con.Close();

                //10AvgNumUsersDuringBusinessHoursByWeek
                con.Open();
                cmd = new SqlCommand("select Field1 as [Week], Field2 as AvgUsers from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'AvgNumUsersDuringBusinessHoursByWeek' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                AvgNumUsersDuringBusinessHoursByWeek.DataSource = rdr;
                AvgNumUsersDuringBusinessHoursByWeek.DataBind();
                con.Close();

                //11LoginsWithNoLicenses
                con.Open();
                cmd = new SqlCommand("select Field1 as LoginAttempts, Field2 as DistinctUserAttempts, Field3 as DayofMonth from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'LoginsWithNoLicenses' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                LoginsWithNoLicenses.DataSource = rdr;
                LoginsWithNoLicenses.DataBind();
                con.Close();

                //12License_Notify_User
                con.Open();
                cmd = new SqlCommand("select Field1 as UserNotified, Field2 as [Email]  from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'License_Notify_User' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                License_Notify_User.DataSource = rdr;
                License_Notify_User.DataBind();
                con.Close();

            }
        }
        // Here's where you do stuff.


        public void refreshdata()
        {

            {


                //1Top10 MostActive content

                con = new SqlConnection(@"Data Source=localhost\SQLEXPRESS; Initial Catalog=ensur; User ID=dcs_user; Password=ensurDCS0!; Persist Security Info=True; Min Pool Size=1; Max Pool Size=1000");
                SqlCommand cmd = new SqlCommand("", con);
                con.Open();
                cmd = new SqlCommand("select Field1 as ContentType, Field2 as Documents, Field3 as AvgDocsCreatedPerDay from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'Top10MostActiveContentTypes' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                SqlDataReader rdr = cmd.ExecuteReader();
                Top10MostActiveContentTypes.DataSource = rdr;
                Top10MostActiveContentTypes.DataBind();
                con.Close();

                //2Top10 Users Most Logins
                con.Open();
                cmd = new SqlCommand("select Field1 as UserName, Field2 as LoginCount, Field3 as DocsTouchedPerDay from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'Top10UsersMostLogins' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                Top10UsersMostLogins.DataSource = rdr;
                Top10UsersMostLogins.DataBind();
                con.Close();

                //3Top10 Content Creators
                con.Open();
                cmd = new SqlCommand("select Field1 as UserName, Field2 as UserStatus, Field3 as DocsCreated from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'Top10ContentCreators' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                Top10ContentCreators.DataSource = rdr;
                Top10ContentCreators.DataBind();
                con.Close();

                //4top10MostPopularContent
                con.Open();
                cmd = new SqlCommand("select Field1 as ContentType, Field2 as Documents, Field3 as AvgDocsCreatedDaily from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'top10MostPopularContentTypes' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                top10MostPopularContentTypes.DataSource = rdr;
                top10MostPopularContentTypes.DataBind();
                con.Close();

                //5BusiestTimes
                con.Open();
                cmd = new SqlCommand("select Field1 as HR, Field2 as Transactions from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'BusiestTimes' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                BusiestTimes.DataSource = rdr;
                BusiestTimes.DataBind();
                con.Close();

                //6Slowest
                con.Open();
                cmd = new SqlCommand("select Field1 as HR, Field2 as Transactions from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'TopSlowestTimes' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                TopSlowestTimes.DataSource = rdr;
                TopSlowestTimes.DataBind();
                con.Close();

                //7UsersandLastLogin
                con.Open();
                cmd = new SqlCommand("select Field1 as [User], Field2 as LastLoginDate from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'UsersandLastLogin' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                UsersandLastLogin.DataSource = rdr;
                UsersandLastLogin.DataBind();
                con.Close();

                //8AvgNumUsersDuringBusinessHoursByYear
                con.Open();
                cmd = new SqlCommand("select Field1 as [Year], Field2 as AvgUsers from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'AvgNumUsersDuringBusinessHoursByYear' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                AvgNumUsersDuringBusinessHoursByYear.DataSource = rdr;
                AvgNumUsersDuringBusinessHoursByYear.DataBind();
                con.Close();

                //9AvgNumUsersDuringBusinessHoursByMonth
                con.Open();
                cmd = new SqlCommand("select Field1 as [Month], Field2 as AvgUsers from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'AvgNumUsersDuringBusinessHoursByMonth' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                AvgNumUsersDuringBusinessHoursByMonth.DataSource = rdr;
                AvgNumUsersDuringBusinessHoursByMonth.DataBind();
                con.Close();

                //10AvgNumUsersDuringBusinessHoursByWeek
                con.Open();
                cmd = new SqlCommand("select Field1 as [Week], Field2 as AvgUsers from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'AvgNumUsersDuringBusinessHoursByWeek' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                AvgNumUsersDuringBusinessHoursByWeek.DataSource = rdr;
                AvgNumUsersDuringBusinessHoursByWeek.DataBind();
                con.Close();

                //11LoginsWithNoLicenses
                con.Open();
                cmd = new SqlCommand("select Field1 as LoginAttempts, Field2 as DistinctUserAttempts, Field3 as DayofMonth from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'LoginsWithNoLicenses' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                LoginsWithNoLicenses.DataSource = rdr;
                LoginsWithNoLicenses.DataBind();
                con.Close();

                //12License_Notify_User
                con.Open();
                cmd = new SqlCommand("select Field1 as UserNotified, Field2 as [Email]  from t_reporthistory where clientname = '" + DropDownListClients.SelectedValue + "'and reportname = 'License_Notify_User' and [timestamp] = '" + DropDownListDate.SelectedValue + "'", con);
                rdr = cmd.ExecuteReader();
                License_Notify_User.DataSource = rdr;
                License_Notify_User.DataBind();
                con.Close();
            }


        }

        protected void myListDropDown_Change(object sender, EventArgs e)
        {

            refreshdata();

        }

    }
}


