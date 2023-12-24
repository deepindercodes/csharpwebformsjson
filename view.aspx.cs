using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view : System.Web.UI.Page
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

        litarticletitle.Text = objArticle.articletitle;
        litarticleauthor.Text = objArticle.articleauthor;
        litarticlebody.Text = objArticle.articlebody;
        litarticlecreatedonutc.Text = objArticle.createdonutc.ToString();

        if (objArticle.articleimage != "")
        {
            divimage.Visible = true;
            imgarticle.ImageUrl = objArticle.articleimage;
        }

        Page.Title = litarticletitle.Text;


    }
}