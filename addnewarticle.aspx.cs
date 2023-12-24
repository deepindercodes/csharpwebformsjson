using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

public partial class addnewarticle : System.Web.UI.Page
{
    JavaScriptSerializer serializer = new JavaScriptSerializer();

    protected void Page_Load(object sender, EventArgs e)
    {
        diverror.Visible = false;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string articletitle = txtarticletitle.Text;
        string articleauthor = txtarticleauthor.Text;
        string articlebody = txtarticlebody.Text;
        string articleimage = hdnarticleimage.Value;
        bool articleExists = false;

        jsonData obj_jsonData = new jsonData();

        List<Article> objArticles = new List<Article>();

        string jsonFilePath = Server.MapPath("/db/data.json");

        Int32 pk = 1;

        if (File.Exists(jsonFilePath))
        {
            string jsonData = File.ReadAllText(jsonFilePath);

            obj_jsonData = serializer.Deserialize<jsonData>(jsonData);

            pk = Convert.ToInt32(obj_jsonData.pk);

            pk = pk + 1;

            foreach(Article article in obj_jsonData.articles)
            {
                if(article.articletitle == articletitle)
                {
                    articleExists = true;
                }
            }


            objArticles = obj_jsonData.articles;
        }

        if (articleExists == true)
        {
            lblerror.Text = "Article Already Exists.";
            diverror.Visible = true;
        }
        else
        {
            Article objArticle = new Article();

            objArticle.id = pk.ToString();
            objArticle.articletitle = articletitle;
            objArticle.articleauthor = articleauthor;
            objArticle.articlebody = articlebody;
            objArticle.articleimage = articleimage;
            objArticle.createdonutc = DateTime.UtcNow.ToString();
            objArticle.status = "E";

            obj_jsonData.pk = pk.ToString();

            objArticles.Add(objArticle);
            obj_jsonData.articles = objArticles;

            string jsonData = serializer.Serialize(obj_jsonData);

            File.WriteAllText(jsonFilePath, jsonData);

            Response.Write("<script type='text/javascript'>parent.newArticleAdded();</script>");
            Response.End();
        }
    }
}