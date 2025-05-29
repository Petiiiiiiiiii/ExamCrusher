#region Where
//listát ad vissza
var result = collection.Where(item => item.Age > 18);
#endregion

#region Select
//változót ad vissza
var names = collection.Select(item => item.Name);
#endregion

#region OrderBy
//listát ad vissza
var ordered = collection.OrderBy(item => item.Date);
#endregion

#region ThenBy
//listát ad vissza
// Elsõdleges rendezés: kategória szerint abc sorrend
// Másodlagos rendezés: ár szerint csökkenõ
// Harmadlagos rendezés: készlet szerint növekvõ
var sortedProducts = products.OrderBy(p => p.Category).ThenByDescending(p => p.Price).ThenBy(p => p.Stock).ToList();
#endregion

#region GroupBy
//IGrouping<TKey, TElement> ad vissza
var groups = collection.GroupBy(item => item.Department);
#endregion

#region First / FirstOrDefault
//példa szerint nézve a collection lista elsõ elemét adja vissza
var first = collection.First(); //ha nincs benne semmi => error
var first = collection.FirstOrDefault(); //ha nincs benne semmi => null-t ad vissza
#endregion

#region Last / LastOrDefault
//példa szerint nézve a collection lista utolsó elemét adja vissza
var last = collection.Last(item => item.IsActive); //ha nincs benne semmi => error
var last = collection.LastOrDefault(item => item.IsActive); //ha nincs benne semmi => null-t ad vissza
#endregion

#region ElementAt / ElementAtOrDefault
//példa szerint nézve a collection lista megadott indexû elemét adja vissza
var thirdItem = collection.ElementAt(2); //ha nincs ilyen indexû elem => error
var thirdItem = collection.ElementAtOrDefault(2); //ha nincs ilyen indexû elem => null-t ad vissza
#endregion

#region Sum / Average / Min / Max
//egy számot ad vissza
var total = collection.Sum(item => item.Price);
var total = collection.Average(item => item.Price);
var total = collection.Min(item => item.Price);
var total = collection.Max(item => item.Price);
#endregion

#region MinBy / MaxBy
//példa szerint nézve a collection lista legnagyob/legkisebb árú ELEMÉT adja vissza
var total = collection.MaxBy(item => item.Price);
var total = collection.MinBy(item => item.Price);
#endregion

#region Distinct / Union / Intersect / Except
//listát ad vissza 

//Disctinct
int[] numbers = { 1, 2, 2, 3, 4, 4, 4 };
var uniqueNumbers = numbers.Distinct();  // output { 1, 2, 3, 4 }

//Union -> Únió
int[] nums1 = { 1, 2, 3 };
int[] nums2 = { 3, 4, 5 };
var union = nums1.Union(nums2);  // output { 1, 2, 3, 4, 5 }

//Intersect -> Metszet
int[] numsA = { 1, 2, 3, 4 };
int[] numsB = { 3, 4, 5, 6 };
var commonItems = numsA.Intersect(numsB);  // output { 3, 4 }

//Except -> Különbség - Visszaadja azokat az elemeket, amelyek az elsõ kollekcióban vannak, de a másodikban nem.
int[] numsX = { 1, 2, 3, 4 };
int[] numsY = { 3, 4, 5 };
var difference = numsX.Except(numsY);  // output { 1, 2 }
#endregion

#region Skip / Take
//listát ad vissza
var numbers = Enumerable.Range(1, 100); // 1-100 feltölti
var page3 = numbers.Skip(20).Take(10);  // 21-30 => page3[0] = 21, page3[1] = 22, page3[2] = 23 ... page[9] = 30
#endregion

#region TakeWhile / SkipWhile
//listát ad vissza
int[] numbers = { 1, 2, 3, 4, 5, 1, 2 };
var taken = numbers.TakeWhile(n => n < 4);  // output [1, 2, 3] (megáll, ha n >= 4)
var skipped = numbers.SkipWhile(n => n < 4); // output [4, 5, 1, 2] (átugorja az elsõ 3-at)
#endregion

#region Concat
//listát ad vissza
//Concat mindent összefûz, Union eltávolítja a duplikátumokat.
var list1 = new[] { "A", "B" };
var list2 = new[] { "C", "D" };
var combined = list1.Concat(list2);  // output ["A", "B", "C", "D"]
#endregion

#region Any
//true-t vagy false-t ad vissza
var numbers = new[] { 1, 2, 3 };
bool hasEven = numbers.Any(n => n % 2 == 0);  // true (a 2 páros)

/*
Ha csak a kollekció ürességét kell ellenõrizni, használd a paraméter nélküli változatot:
if (list.Any()) { ... } (hatékonyabb, mint list.Count() > 0).
*/
#endregion

#region All
//true-t vagy false-t ad vissza
//True-t ad vissza, ha minden elem megfelel a feltételnek.
var ages = new[] { 18, 20, 25 };
bool allAdults = ages.All(age => age >= 18);  // true
#endregion

#region Contains
//true-t vagy false-t ad vissza
//True-t ad vissza, ha minden elem megfelel a feltételnek.
var fruits = new[] { "Apple", "Banana", "Orange" };
bool hasBanana = fruits.Contains("Banana");  // true
#endregion


//Példa egy kombinált lekérdezésre
var activeUsers = users
    .Where(u => u.IsActive)
    .OrderBy(u => u.LastName)
    .Select(u => new { ID = u.Id, FullName = $"{u.FirstName} {u.LastName}" })
    .Take(10)
    .ToList();

