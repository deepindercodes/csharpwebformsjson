using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    JavaScriptSerializer serializer = new JavaScriptSerializer();
    protected void Page_Load(object sender, EventArgs e)
    {
        jsonData obj_jsonData = new jsonData();

        List<Article> objArticles = new List<Article>();

        string jsonFilePath = Server.MapPath("/db/data.json");

        if (File.Exists(jsonFilePath))
        {
            string jsonData = File.ReadAllText(jsonFilePath);

            obj_jsonData = serializer.Deserialize<jsonData>(jsonData);

            reparticles.DataSource = obj_jsonData.articles;
            reparticles.DataBind();
        }


    }
}