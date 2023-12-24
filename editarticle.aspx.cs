using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class editarticle : System.Web.UI.Page
{
    JavaScriptSerializer serializer = new JavaScriptSerializer();

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Int32 id = Convert.ToInt32(Request["id"]);

            jsonData obj_jsonData = new jsonData();

            List<Article> objArticles = new List<Article>();

            string jsonFilePath = Server.MapPath("/db/data.json");

            string jsonData = File.ReadAllText(jsonFilePath);

            obj_jsonData = serializer.Deserialize<jsonData>(jsonData);

            Article objArticle = obj_jsonData.articles.Where(u => u.id == id.ToString()).FirstOrDefault();

            txtarticletitle.Text = objArticle.articletitle;
            txtarticleauthor.Text = objArticle.articleauthor;
            txtarticlebody.Text = objArticle.articlebody;
            hdnarticleimage.Value = objArticle.articleimage;
        }

    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Int32 id = Convert.ToInt32(Request["id"]);

        string articletitle = txtarticletitle.Text;
        string articleauthor = txtarticleauthor.Text;
        string articlebody = txtarticlebody.Text;
        string articleimage = hdnarticleimage.Value;

        jsonData obj_jsonData = new jsonData();

        List<Article> objArticles = new List<Article>();

        string jsonFilePath = Server.MapPath("/db/data.json");

        string jsonData = File.ReadAllText(jsonFilePath);

        obj_jsonData = serializer.Deserialize<jsonData>(jsonData);

        Article objArticle = obj_jsonData.articles.Where(u => u.id == id.ToString()).FirstOrDefault();

        objArticle.articletitle = articletitle;
        objArticle.articleauthor = articleauthor;
        objArticle.articlebody = articlebody;
        objArticle.articleimage = articleimage;
        objArticle.modifiedonutc = DateTime.UtcNow.ToString();

        jsonData = serializer.Serialize(obj_jsonData);

        File.WriteAllText(jsonFilePath, jsonData);


        Response.Write("<script type='text/javascript'>parent.ArticleEdited();</script>");
        Response.End();
    }
}