int p, m, l, n, res;
p = 5;
m = 3;
l = 3;
n = Convert.ToInt32(Console.ReadLine());
res = (p + m * 2 + l * 2 + l * (n - 1) + p) * n;
Console.WriteLine(res);
