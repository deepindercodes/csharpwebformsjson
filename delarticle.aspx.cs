using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

public partial class delarticle : System.Web.UI.Page
{
    JavaScriptSerializer serializer = new JavaScriptSerializer();

    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 id = Convert.ToInt32(Request["id"]);

        jsonData obj_jsonData = new jsonData();

        List<Article> objArticles = new List<Article>();

        string jsonFilePath = Server.MapPath("/db/data.json");

        string jsonData = File.ReadAllText(jsonFilePath);

        obj_jsonData = serializer.Deserialize<jsonData>(jsonData);

        Article objArticle = obj_jsonData.articles.Where(u => u.id == id.ToString()).FirstOrDefault();

        obj_jsonData.articles.Remove(objArticle);

        jsonData = serializer.Serialize(obj_jsonData);

        File.WriteAllText(jsonFilePath, jsonData);

        Response.Redirect("/");

    }
}