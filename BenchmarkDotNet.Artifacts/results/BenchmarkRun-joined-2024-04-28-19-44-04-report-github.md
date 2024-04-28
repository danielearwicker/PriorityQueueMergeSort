```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 8.0.100
  [Host]     : .NET 6.0.29 (6.0.2924.17105), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 6.0.29 (6.0.2924.17105), Arm64 RyuJIT AdvSIMD


```
| Type                  | Method      | ChunkCount | Algorithm           | Mean       | Error     | StdDev    |
|---------------------- |------------ |----------- |-------------------- |-----------:|----------:|----------:|
| **BenchmarksIntSync**     | **IntSync**     | **2**          | **BinaryArray_Sync**    |   **6.321 ms** | **0.0075 ms** | **0.0063 ms** |
| BenchmarksStringSync  | StringSync  | 2          | BinaryArray_Sync    |  19.960 ms | 0.0346 ms | 0.0323 ms |
| **BenchmarksIntSync**     | **IntSync**     | **2**          | **BinaryLinked_Sync**   |   **5.090 ms** | **0.0080 ms** | **0.0066 ms** |
| BenchmarksStringSync  | StringSync  | 2          | BinaryLinked_Sync   |  19.587 ms | 0.0459 ms | 0.0407 ms |
| **BenchmarksIntAsync**    | **IntAsync**    | **2**          | **PriorityQueue_Async** |   **6.652 ms** | **0.0131 ms** | **0.0116 ms** |
| BenchmarksStringAsync | StringAsync | 2          | PriorityQueue_Async |  21.825 ms | 0.0352 ms | 0.0329 ms |
| **BenchmarksIntSync**     | **IntSync**     | **2**          | **PriorityQueue_Sync**  |   **2.604 ms** | **0.0037 ms** | **0.0035 ms** |
| BenchmarksStringSync  | StringSync  | 2          | PriorityQueue_Sync  |  16.199 ms | 0.0178 ms | 0.0158 ms |
| **BenchmarksIntSync**     | **IntSync**     | **2**          | **SortedLinked_Sync**   |   **3.943 ms** | **0.0069 ms** | **0.0061 ms** |
| BenchmarksStringSync  | StringSync  | 2          | SortedLinked_Sync   |  17.592 ms | 0.0221 ms | 0.0206 ms |
| **BenchmarksIntSync**     | **IntSync**     | **2**          | **SortedList_Sync**     |   **5.346 ms** | **0.0065 ms** | **0.0061 ms** |
| BenchmarksStringSync  | StringSync  | 2          | SortedList_Sync     |  18.943 ms | 0.0144 ms | 0.0121 ms |
| **BenchmarksIntSync**     | **IntSync**     | **2**          | **SortedSet_Sync**      |  **22.314 ms** | **0.0632 ms** | **0.0528 ms** |
| BenchmarksStringSync  | StringSync  | 2          | SortedSet_Sync      |  47.531 ms | 0.0960 ms | 0.0802 ms |
| **BenchmarksIntAsync**    | **IntAsync**    | **2**          | **SuperLinq_Async**     |   **8.336 ms** | **0.0353 ms** | **0.0294 ms** |
| BenchmarksStringAsync | StringAsync | 2          | SuperLinq_Async     |  23.479 ms | 0.0463 ms | 0.0410 ms |
| **BenchmarksIntSync**     | **IntSync**     | **2**          | **SuperLinq_Sync**      |   **2.050 ms** | **0.0396 ms** | **0.0370 ms** |
| BenchmarksStringSync  | StringSync  | 2          | SuperLinq_Sync      |  15.058 ms | 0.0176 ms | 0.0156 ms |
| **BenchmarksIntSync**     | **IntSync**     | **5**          | **BinaryArray_Sync**    |   **8.165 ms** | **0.0098 ms** | **0.0087 ms** |
| BenchmarksStringSync  | StringSync  | 5          | BinaryArray_Sync    |  31.820 ms | 0.0418 ms | 0.0349 ms |
| **BenchmarksIntSync**     | **IntSync**     | **5**          | **BinaryLinked_Sync**   |   **7.180 ms** | **0.0222 ms** | **0.0208 ms** |
| BenchmarksStringSync  | StringSync  | 5          | BinaryLinked_Sync   |  31.536 ms | 0.1702 ms | 0.1421 ms |
| **BenchmarksIntAsync**    | **IntAsync**    | **5**          | **PriorityQueue_Async** |   **7.406 ms** | **0.0087 ms** | **0.0073 ms** |
| BenchmarksStringAsync | StringAsync | 5          | PriorityQueue_Async |  43.089 ms | 0.0527 ms | 0.0493 ms |
| **BenchmarksIntSync**     | **IntSync**     | **5**          | **PriorityQueue_Sync**  |   **3.219 ms** | **0.0048 ms** | **0.0042 ms** |
| BenchmarksStringSync  | StringSync  | 5          | PriorityQueue_Sync  |  37.991 ms | 0.0524 ms | 0.0490 ms |
| **BenchmarksIntSync**     | **IntSync**     | **5**          | **SortedLinked_Sync**   |   **4.897 ms** | **0.0113 ms** | **0.0106 ms** |
| BenchmarksStringSync  | StringSync  | 5          | SortedLinked_Sync   |  31.242 ms | 0.0451 ms | 0.0422 ms |
| **BenchmarksIntSync**     | **IntSync**     | **5**          | **SortedList_Sync**     |   **6.745 ms** | **0.0081 ms** | **0.0071 ms** |
| BenchmarksStringSync  | StringSync  | 5          | SortedList_Sync     |  33.257 ms | 0.0905 ms | 0.0847 ms |
| **BenchmarksIntSync**     | **IntSync**     | **5**          | **SortedSet_Sync**      |  **25.909 ms** | **0.0468 ms** | **0.0438 ms** |
| BenchmarksStringSync  | StringSync  | 5          | SortedSet_Sync      |  76.137 ms | 0.1630 ms | 0.1525 ms |
| **BenchmarksIntAsync**    | **IntAsync**    | **5**          | **SuperLinq_Async**     |  **10.321 ms** | **0.0165 ms** | **0.0154 ms** |
| BenchmarksStringAsync | StringAsync | 5          | SuperLinq_Async     |  46.571 ms | 0.0974 ms | 0.0864 ms |
| **BenchmarksIntSync**     | **IntSync**     | **5**          | **SuperLinq_Sync**      |   **3.698 ms** | **0.0049 ms** | **0.0046 ms** |
| BenchmarksStringSync  | StringSync  | 5          | SuperLinq_Sync      |  38.459 ms | 0.0551 ms | 0.0489 ms |
| **BenchmarksIntSync**     | **IntSync**     | **50**         | **BinaryArray_Sync**    |  **13.756 ms** | **0.0227 ms** | **0.0212 ms** |
| BenchmarksStringSync  | StringSync  | 50         | BinaryArray_Sync    |  61.267 ms | 0.1201 ms | 0.1065 ms |
| **BenchmarksIntSync**     | **IntSync**     | **50**         | **BinaryLinked_Sync**   |  **22.065 ms** | **0.0480 ms** | **0.0449 ms** |
| BenchmarksStringSync  | StringSync  | 50         | BinaryLinked_Sync   |  68.802 ms | 0.2833 ms | 0.2650 ms |
| **BenchmarksIntAsync**    | **IntAsync**    | **50**         | **PriorityQueue_Async** |  **10.086 ms** | **0.0123 ms** | **0.0109 ms** |
| BenchmarksStringAsync | StringAsync | 50         | PriorityQueue_Async | 104.350 ms | 0.2020 ms | 0.1790 ms |
| **BenchmarksIntSync**     | **IntSync**     | **50**         | **PriorityQueue_Sync**  |   **5.986 ms** | **0.0127 ms** | **0.0118 ms** |
| BenchmarksStringSync  | StringSync  | 50         | PriorityQueue_Sync  |  99.656 ms | 0.1785 ms | 0.1670 ms |
| **BenchmarksIntSync**     | **IntSync**     | **50**         | **SortedLinked_Sync**   |  **14.718 ms** | **0.0176 ms** | **0.0165 ms** |
| BenchmarksStringSync  | StringSync  | 50         | SortedLinked_Sync   | 186.160 ms | 0.3243 ms | 0.2875 ms |
| **BenchmarksIntSync**     | **IntSync**     | **50**         | **SortedList_Sync**     |  **18.256 ms** | **0.0349 ms** | **0.0327 ms** |
| BenchmarksStringSync  | StringSync  | 50         | SortedList_Sync     | 200.775 ms | 0.3533 ms | 0.3304 ms |
| **BenchmarksIntSync**     | **IntSync**     | **50**         | **SortedSet_Sync**      |  **39.534 ms** | **0.0863 ms** | **0.0807 ms** |
| BenchmarksStringSync  | StringSync  | 50         | SortedSet_Sync      | 157.396 ms | 0.3194 ms | 0.2988 ms |
| **BenchmarksIntAsync**    | **IntAsync**    | **50**         | **SuperLinq_Async**     |  **33.014 ms** | **0.0650 ms** | **0.0608 ms** |
| BenchmarksStringAsync | StringAsync | 50         | SuperLinq_Async     | 374.167 ms | 0.5538 ms | 0.4624 ms |
| **BenchmarksIntSync**     | **IntSync**     | **50**         | **SuperLinq_Sync**      |  **27.100 ms** | **0.0306 ms** | **0.0287 ms** |
| BenchmarksStringSync  | StringSync  | 50         | SuperLinq_Sync      | 362.968 ms | 2.7470 ms | 3.3736 ms |
