using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Framework.Persistence.Ef.Extensions
{
   public static class EfCoreHelper
    {
        public static IOrderedQueryable<TSource> OrderBy<TSource>(
            this IQueryable<TSource> query, string propertyName , string orderByType)
        {
            var entityType = typeof(TSource);

            if (propertyName == null)
            {
                propertyName = "Id";

            }
         
            var propertyInfo = entityType.GetProperty(propertyName);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, propertyName);
            var selector = Expression.Lambda(property, new ParameterExpression[] { arg });

           

            string methodName = orderByType == "ASC" ? "OrderBy" : "OrderByDescending";

            var enumarableType = typeof(System.Linq.Queryable);
            var method = enumarableType.GetMethods()
                .Where(m => m.Name == methodName && m.IsGenericMethodDefinition)
                .Where(m =>
                {
                    var parameters = m.GetParameters().ToList();
                        
                    return parameters.Count == 2;
                }).Single();
           
            MethodInfo genericMethod = method
                .MakeGenericMethod(entityType, propertyInfo.PropertyType);

            var newQuery = (IOrderedQueryable<TSource>)genericMethod
                .Invoke(genericMethod, new object[] { query, selector });
            return newQuery;
        }
    }
}
