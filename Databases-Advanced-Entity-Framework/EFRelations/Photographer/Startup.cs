


namespace Photographer
{
    using System;
    using Models;

    class Startup
    {
        static void Main(string[] args)
        {
            PhotographerContext context = new PhotographerContext();

            
            // Add Valid Tag

            //Tag newTag = new Tag();
            //newTag.Name = "#TheTag";
            //context.Tags.Add(newTag);
            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (DbEntityValidationException)
            //{
            //    newTag.Name = TagTransformer.Transform(newTag.Name);
            //    context.SaveChanges();
            //}


            //var count = context.Photographers.Count();
            //Console.WriteLine(count);
        }
    }
}
