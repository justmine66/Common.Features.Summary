using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Common.Features.Summary.ObjClone
{
    /// <summary>
    /// 利用泛型缓存表达式，高效快速的进行深度克隆对象。
    /// </summary>
    /// <typeparam name="TSource">源类型</typeparam>
    /// <typeparam name="TResult">结果类型</typeparam>
    public class TransObjOnExp<TSource, TResult>
    {
        private static readonly Func<TSource, TResult> cacheGetTransAllSamePropertysFunc = getTransAllSamePropertysFunc();
        private static readonly Func<TSource, TResult> cacheGetTransAllSameFieldsFunc = getTransAllSameFieldsFunc();
        private static Func<TSource, TResult> getTransAllSamePropertysFunc()
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TSource), "p");
            List<MemberBinding> memberBindingList = new List<MemberBinding>();

            foreach (var item in typeof(TResult).GetProperties())
            {
                if (!item.CanWrite)
                    continue;

                MemberExpression property = Expression.Property(parameterExpression, typeof(TSource).GetProperty(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }

            MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TResult)), memberBindingList.ToArray());
            Expression<Func<TSource, TResult>> lambda = Expression.Lambda<Func<TSource, TResult>>(memberInitExpression, new ParameterExpression[] { parameterExpression });

            return lambda.Compile();
        }

        private static Func<TSource, TResult> getTransAllSameFieldsFunc()
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TSource), "p");
            List<MemberBinding> memberBindingList = new List<MemberBinding>();

            foreach (var item in typeof(TResult).GetFields())
            {
                if (!item.IsPrivate)
                    continue;

                MemberExpression field = Expression.Field(parameterExpression, typeof(TSource).GetField(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, field);
                memberBindingList.Add(memberBinding);
            }

            MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TResult)), memberBindingList.ToArray());
            Expression<Func<TSource, TResult>> lambda = Expression.Lambda<Func<TSource, TResult>>(memberInitExpression, new ParameterExpression[] { parameterExpression });

            return lambda.Compile();
        }

        /// <summary>
        /// 转化源对象所有相同的属性到结果对象
        /// </summary>
        /// <param name="TSource">源对象</param>
        /// <returns>结果对象</returns>
        public static TResult TransAllSamePropertys(TSource TSource)
        {
            return cacheGetTransAllSamePropertysFunc(TSource);
        }

        /// <summary>
        /// 转化源对象所有相同的字段到结果对象
        /// </summary>
        /// <param name="TSource">源对象</param>
        /// <returns>结果对象</returns>
        public static TResult TransAllSameFields(TSource TSource)
        {
            return cacheGetTransAllSameFieldsFunc(TSource);
        }
    }
}
