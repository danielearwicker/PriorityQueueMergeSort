namespace PriorityQueueMergeSort.Algorithms;

using SuperLinq;
using System;
using System.Collections.Generic;
using System.Linq;

public static class SortedSetSortedMergeExtensions
{
    public static T Identity<T>(T x) => x;

    internal record class ReverseComparer<T>(IComparer<T> underlying) : IComparer<T>
    {
        public int Compare(T? x, T? y) =>
            -underlying.Compare(x, y);
    }

    //
    // Summary:
    //     Merges two or more sequences that are in a common order into a single sequence
    //     that preserves that order.
    //
    // Parameters:
    //   source:
    //     The primary sequence with which to merge
    //
    //   otherSequences:
    //     A variable argument array of zero or more other sequences to merge with
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of the sequence
    //
    // Returns:
    //     A merged, order-preserving sequence containing all of the elements of the original
    //     sequences
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     source or otherSequences is null.
    //
    // Remarks:
    //     Using SsSortedMerge on sequences that are not ordered or are not in the same order
    //     produces undefined results.
    //
    //     This method uses deferred execution and streams its results.
    public static IEnumerable<TSource> SsSortedMerge<TSource>(this IEnumerable<TSource> source, params IEnumerable<TSource>[] otherSequences)
        where TSource : notnull
    {
        return source.SsSortedMerge(OrderByDirection.Ascending, null, otherSequences);
    }

    //
    // Summary:
    //     Merges two or more sequences that are in a common order (either ascending or
    //     descending) into a single sequence that preserves that order.
    //
    // Parameters:
    //   source:
    //     The primary sequence with which to merge
    //
    //   otherSequences:
    //     A variable argument array of zero or more other sequences to merge with
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of the sequence
    //
    // Returns:
    //     A merged, order-preserving sequence containing all of the elements of the original
    //     sequences
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     source is null.
    //
    //   T:System.ArgumentNullException:
    //     otherSequences is null.
    //
    // Remarks:
    //     Using SsSortedMergeDescending on sequences that are not ordered or are not in the
    //     same order produces undefined results.
    //     This method uses deferred execution and streams its results.
    //     Here is an example of a merge, as well as the produced result:
    //
    //     var s1 = new[] { 3, 7, 11 };
    //     var s2 = new[] { 2, 4, 20 };
    //     var s3 = new[] { 17, 19, 25 };
    //     var merged = s1.SsSortedMerge( OrderByDirection.Ascending, s2, s3 );
    //     var result = merged.ToArray();
    //     // result will be:
    //     // { 2, 3, 4, 7, 11, 17, 19, 20, 25 }
    public static IEnumerable<TSource> SsSortedMergeDescending<TSource>(this IEnumerable<TSource> source, params IEnumerable<TSource>[] otherSequences)
        where TSource : notnull
    {
        return source.SsSortedMerge(OrderByDirection.Descending, null, otherSequences);
    }

    //
    // Summary:
    //     Merges two or more sequences that are in a common order into a single sequence
    //     that preserves that order.
    //
    // Parameters:
    //   source:
    //     The primary sequence with which to merge
    //
    //   otherSequences:
    //     A variable argument array of zero or more other sequences to merge with
    //
    //   comparer:
    //     An System.Collections.Generic.IComparer`1 to compare elements
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of the sequence
    //
    // Returns:
    //     A merged, order-preserving sequence containing all of the elements of the original
    //     sequences
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     source or otherSequences is null.
    //
    // Remarks:
    //     Using SsSortedMerge on sequences that are not ordered or are not in the same order
    //     produces undefined results.
    //
    //     This method uses deferred execution and streams its results.
    public static IEnumerable<TSource> SsSortedMerge<TSource>(this IEnumerable<TSource> source, IComparer<TSource>? comparer, params IEnumerable<TSource>[] otherSequences)
        where TSource : notnull
    {
        return source.SsSortedMerge(OrderByDirection.Ascending, comparer, otherSequences);
    }

    //
    // Summary:
    //     Merges two or more sequences that are in a common order (either ascending or
    //     descending) into a single sequence that preserves that order.
    //
    // Parameters:
    //   source:
    //     The primary sequence with which to merge
    //
    //   comparer:
    //     The comparer used to evaluate the relative order between elements
    //
    //   otherSequences:
    //     A variable argument array of zero or more other sequences to merge with
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of the sequence
    //
    // Returns:
    //     A merged, order-preserving sequence containing all of the elements of the original
    //     sequences
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     source is null.
    //
    //   T:System.ArgumentNullException:
    //     otherSequences is null.
    //
    // Remarks:
    //     Using SsSortedMergeDescending on sequences that are not ordered or are not in the
    //     same order produces undefined results.
    //     This method uses deferred execution and streams its results.
    //     Here is an example of a merge, as well as the produced result:
    //
    //     var s1 = new[] { 3, 7, 11 };
    //     var s2 = new[] { 2, 4, 20 };
    //     var s3 = new[] { 17, 19, 25 };
    //     var merged = s1.SsSortedMerge( OrderByDirection.Ascending, s2, s3 );
    //     var result = merged.ToArray();
    //     // result will be:
    //     // { 2, 3, 4, 7, 11, 17, 19, 20, 25 }
    public static IEnumerable<TSource> SsSortedMergeDescending<TSource>(this IEnumerable<TSource> source, IComparer<TSource>? comparer, params IEnumerable<TSource>[] otherSequences)
        where TSource : notnull
    {
        return source.SsSortedMerge(OrderByDirection.Descending, comparer, otherSequences);
    }

    //
    // Summary:
    //     Merges two or more sequences that are in a common order (either ascending or
    //     descending) into a single sequence that preserves that order.
    //
    // Parameters:
    //   source:
    //     The primary sequence with which to merge
    //
    //   otherSequences:
    //     A variable argument array of zero or more other sequences to merge with
    //
    //   direction:
    //     A direction in which to order the elements (ascending, descending)
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of the sequence
    //
    // Returns:
    //     A merged, order-preserving sequence containing all of the elements of the original
    //     sequences
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     source or otherSequences is null.
    //
    // Remarks:
    //     Using SsSortedMerge on sequences that are not ordered or are not in the same order
    //     produces undefined results.
    //
    //     This method uses deferred execution and streams its results.
    public static IEnumerable<TSource> SsSortedMerge<TSource>(this IEnumerable<TSource> source, OrderByDirection direction, params IEnumerable<TSource>[] otherSequences)
        where TSource : notnull
    {
        return source.SsSortedMerge(direction, null, otherSequences);
    }

    //
    // Summary:
    //     Merges two or more sequences that are in a common order (either ascending or
    //     descending) into a single sequence that preserves that order.
    //
    // Parameters:
    //   source:
    //     The primary sequence with which to merge
    //
    //   otherSequences:
    //     A variable argument array of zero or more other sequences to merge with
    //
    //   direction:
    //     A direction in which to order the elements (ascending, descending)
    //
    //   comparer:
    //     An System.Collections.Generic.IComparer`1 to compare elements
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of the sequence
    //
    // Returns:
    //     A merged, order-preserving sequence containing all of the elements of the original
    //     sequences
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     source or otherSequences is null.
    //
    // Remarks:
    //     Using SsSortedMerge on sequences that are not ordered or are not in the same order
    //     produces undefined results.
    //
    //     This method uses deferred execution and streams its results.
    public static IEnumerable<TSource> SsSortedMerge<TSource>(this IEnumerable<TSource> source, OrderByDirection direction, IComparer<TSource>? comparer, params IEnumerable<TSource>[] otherSequences)
        where TSource : notnull
    {
        return source.SsSortedMergeBy(Identity, direction, comparer, otherSequences);
    }

    //
    // Summary:
    //     Merges two or more sequences that are in a common order according to a key into
    //     a single sequence that preserves that order.
    //
    // Parameters:
    //   source:
    //     The primary sequence with which to merge
    //
    //   keySelector:
    //     A key selector function
    //
    //   otherSequences:
    //     A variable argument array of zero or more other sequences to merge with
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of the sequence
    //
    //   TKey:
    //     The type of the key used to order elements
    //
    // Returns:
    //     A merged, order-preserving sequence containing all of the elements of the original
    //     sequences
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     source, keySelector or otherSequences is null.
    //
    // Remarks:
    //     Using SsSortedMergeBy on sequences that are not ordered or are not in the same
    //     order produces undefined results.
    //
    //     This method uses deferred execution and streams its results.
    public static IEnumerable<TSource> SsSortedMergeBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, params IEnumerable<TSource>[] otherSequences)
        where TKey : notnull
    {
        return source.SsSortedMergeBy(keySelector, OrderByDirection.Ascending, null, otherSequences);
    }

    //
    // Summary:
    //     Merges two or more sequences that are in a common order (either ascending or
    //     descending) according to a key into a single sequence that preserves that order.
    //
    //
    // Parameters:
    //   source:
    //     The primary sequence with which to merge
    //
    //   keySelector:
    //     A function to extract a key from an element.
    //
    //   otherSequences:
    //     A variable argument array of zero or more other sequences to merge with
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of the sequence
    //
    //   TKey:
    //     The type of the key returned by keySelector
    //
    // Returns:
    //     A merged, order-preserving sequence containing all of the elements of the original
    //     sequences
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     source is null.
    //
    //   T:System.ArgumentNullException:
    //     keySelector is null.
    //
    //   T:System.ArgumentNullException:
    //     otherSequences is null.
    //
    // Remarks:
    //     Using SsSortedMergeByDescending on sequences that are not ordered or are not in
    //     the same order produces undefined results.
    //     This method uses deferred execution and streams its results.
    public static IEnumerable<TSource> SsSortedMergeByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, params IEnumerable<TSource>[] otherSequences)
        where TKey : notnull
    {
        return source.SsSortedMergeBy(keySelector, OrderByDirection.Descending, null, otherSequences);
    }

    //
    // Summary:
    //     Merges two or more sequences that are in a common order according to a key into
    //     a single sequence that preserves that order.
    //
    // Parameters:
    //   source:
    //     The primary sequence with which to merge
    //
    //   keySelector:
    //     A key selector function
    //
    //   otherSequences:
    //     A variable argument array of zero or more other sequences to merge with
    //
    //   comparer:
    //     An System.Collections.Generic.IComparer`1 to compare keys
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of the sequence
    //
    //   TKey:
    //     The type of the key used to order elements
    //
    // Returns:
    //     A merged, order-preserving sequence containing all of the elements of the original
    //     sequences
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     source, keySelector or otherSequences is null.
    //
    // Remarks:
    //     Using SsSortedMergeBy on sequences that are not ordered or are not in the same
    //     order produces undefined results.
    //
    //     This method uses deferred execution and streams its results.
    public static IEnumerable<TSource> SsSortedMergeBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer, params IEnumerable<TSource>[] otherSequences)
        where TKey : notnull
    {
        return source.SsSortedMergeBy(keySelector, OrderByDirection.Ascending, comparer, otherSequences);
    }

    //
    // Summary:
    //     Merges two or more sequences that are in a common order (either ascending or
    //     descending) according to a key into a single sequence that preserves that order.
    //
    //
    // Parameters:
    //   source:
    //     The primary sequence with which to merge
    //
    //   keySelector:
    //     A function to extract a key from an element.
    //
    //   comparer:
    //     The comparer used to evaluate the relative order between elements
    //
    //   otherSequences:
    //     A variable argument array of zero or more other sequences to merge with
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of the sequence
    //
    //   TKey:
    //     The type of the key returned by keySelector
    //
    // Returns:
    //     A merged, order-preserving sequence containing all of the elements of the original
    //     sequences
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     source is null.
    //
    //   T:System.ArgumentNullException:
    //     keySelector is null.
    //
    //   T:System.ArgumentNullException:
    //     otherSequences is null.
    //
    // Remarks:
    //     Using SsSortedMergeByDescending on sequences that are not ordered or are not in
    //     the same order produces undefined results.
    //     This method uses deferred execution and streams its results.
    public static IEnumerable<TSource> SsSortedMergeByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer, params IEnumerable<TSource>[] otherSequences)
        where TKey : notnull
    {
        return source.SsSortedMergeBy(keySelector, OrderByDirection.Descending, comparer, otherSequences);
    }

    //
    // Summary:
    //     Merges two or more sequences that are in a common order (either ascending or
    //     descending) according to a key into a single sequence that preserves that order.
    //
    //
    // Parameters:
    //   source:
    //     The primary sequence with which to merge
    //
    //   keySelector:
    //     A key selector function
    //
    //   otherSequences:
    //     A variable argument array of zero or more other sequences to merge with
    //
    //   direction:
    //     A direction in which to order the elements (ascending, descending)
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of the sequence
    //
    //   TKey:
    //     The type of the key used to order elements
    //
    // Returns:
    //     A merged, order-preserving sequence containing all of the elements of the original
    //     sequences
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     source, keySelector or otherSequences is null.
    //
    // Remarks:
    //     Using SsSortedMergeBy on sequences that are not ordered or are not in the same
    //     order produces undefined results.
    //
    //     This method uses deferred execution and streams its results.
    public static IEnumerable<TSource> SsSortedMergeBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, OrderByDirection direction, params IEnumerable<TSource>[] otherSequences)
        where TKey : notnull
    {
        return source.SsSortedMergeBy(keySelector, direction, null, otherSequences);
    }

    //
    // Summary:
    //     Merges two or more sequences that are in a common order (either ascending or
    //     descending) according to a key into a single sequence that preserves that order.
    //
    //
    // Parameters:
    //   source:
    //     The primary sequence with which to merge
    //
    //   keySelector:
    //     A key selector function
    //
    //   otherSequences:
    //     A variable argument array of zero or more other sequences to merge with
    //
    //   direction:
    //     A direction in which to order the elements (ascending, descending)
    //
    //   comparer:
    //     An System.Collections.Generic.IComparer`1 to compare keys
    //
    // Type parameters:
    //   TSource:
    //     The type of the elements of the sequence
    //
    //   TKey:
    //     The type of the key used to order elements
    //
    // Returns:
    //     A merged, order-preserving sequence containing all of the elements of the original
    //     sequences
    //
    // Exceptions:
    //   T:System.ArgumentNullException:
    //     source, keySelector or otherSequences is null.
    //
    // Remarks:
    //     Using SsSortedMergeBy on sequences that are not ordered or are not in the same
    //     order produces undefined results.
    //
    //     This method uses deferred execution and streams its results.
    public static IEnumerable<TSource> SsSortedMergeBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, OrderByDirection direction, IComparer<TKey>? comparer, params IEnumerable<TSource>[] otherSequences)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(source, "source");
        ArgumentNullException.ThrowIfNull(keySelector, "keySelector");
        ArgumentNullException.ThrowIfNull(otherSequences, "otherSequences");
        if (otherSequences.Length == 0)
        {
            return source;
        }

        if (comparer == null)
        {
            comparer = Comparer<TKey>.Default;
        }

        if (direction == OrderByDirection.Descending)
        {
            comparer = new ReverseComparer<TKey>(comparer);
        }

        return Impl(otherSequences.Prepend(source), keySelector, comparer);
        static IEnumerable<TSource> Impl(IEnumerable<IEnumerable<TSource>> sources, Func<TSource, TKey> keySelector, IComparer<TKey> comparer)
        {
            var enumerators = sources.Select(x => x.GetEnumerator()).ToList();

            var queue = new SortedQueueOverSortedSetOfBuckets<IEnumerator<TSource>, TKey>(comparer);

            foreach (var e in enumerators)
            {
                if (e.MoveNext()) queue.Enqueue(e, keySelector(e.Current));
            }

            try
            {
                while (queue.TryDequeue(out var e, out var _))
                {
                    yield return e.Current;

                    if (e.MoveNext()) queue.Enqueue(e, keySelector(e.Current));
                }
            }
            finally
            {
                foreach (var e in enumerators)
                {
                    e.Dispose();
                }
            }
        }
    }

    internal class SortedQueueOverSortedSetOfBuckets<TItem, TKey> where TKey : notnull
    {
        private readonly SortedDictionary<TKey, List<TItem>> _buckets;

        public SortedQueueOverSortedSetOfBuckets(IComparer<TKey> keyComparer)
            => _buckets = new(keyComparer);
        
        public void Enqueue(TItem item, TKey key)
        {
            if (!_buckets.TryGetValue(key, out var existingBucket))
            {
                _buckets.Add(key, new List<TItem> { item });
            }
            else
            {
                existingBucket.Add(item);
            }
        }

        public bool TryDequeue(out TItem item, out TKey key)
        {            
            if (_buckets.Count == 0)
            {
                item = default!;
                key = default!;
                return false;
            }

            var min = _buckets.First();
            item = min.Value[^1];
            key = min.Key;

            min.Value.RemoveAt(min.Value.Count - 1);
            if (min.Value.Count == 0)
            {
                _buckets.Remove(min.Key);
            }
            return true;
        }
    }
}
