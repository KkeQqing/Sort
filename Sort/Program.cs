using System.Collections.Concurrent;

namespace Sort;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = { 5, 2, 9, 1, 5, 6,7, 3 , 11 };

        SelectionSort(nums);
        Console.WriteLine("SelectionSort:\t " + string.Join(", ", nums));
        RestoreArr(nums);

        InsertionSort(nums);
        Console.WriteLine("InsertionSort:\t " + string.Join(", ", nums));
        RestoreArr(nums);

        QuickSort(nums);
        Console.WriteLine("QuickSort:\t " + string.Join(", ", nums));
        RestoreArr(nums);

        MergeSort(nums);
        Console.WriteLine("MergeSort:\t " + string.Join(", ", nums));
        RestoreArr(nums);

        ShellSort(nums);
        Console.WriteLine("ShellSort:\t " + string.Join(", ", nums));
        RestoreArr(nums);

        HeapSort(nums);
        Console.WriteLine("HeapSort:\t " + string.Join(", ", nums));
        RestoreArr(nums);

    }

    static void SelectionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n-1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = arr[i];
            arr[i] = arr[minIndex];
            arr[minIndex] = temp;
        }

    }

    static void InsertionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; i++) 
        {
            int key = arr[i];
            int k = i - 1;
            while (k >= 0 && arr[k] > key)
            {
                arr[k + 1] = arr[k];
                k--;
            }
            arr[k + 1] = key;
        }
    }

    static void QuickSort(int[] arr)
    {
        int n = arr.Length;
        QuickSort(arr, 0 , n-1);
    }

    static private void QuickSort(int[] arr, int left, int right)
    {
        if (left >= right) return;
        int pivotIndex = Partition(arr, left, right);
        QuickSort(arr, left, pivotIndex);
        QuickSort(arr, pivotIndex+1, right);
    }
    
    static int Partition(int[] arr,int left,int right)
    {
        int pivot = arr[left];
        int i = left - 1;
        int j = right + 1;
        while (true)
        {
            do
            {
                i++;
            } while (arr[i] < pivot);
            do
            {
                j--;
            }while(arr[j] > pivot);
            if(i>= j)
            {
                return j;
            }
            Swap(arr, i, j);
        }
    }
    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static void MergeSort(int[] arr)
    {
        if(arr == null|| arr.Length == 0) return;
        int n = arr.Length;
        MergeSort(arr, 0, n -1);
    }
    static void MergeSort(int[] arr, int left, int right)
    {
        if(left >= right) return;

        int mid = left + (right - left) / 2; // 防溢出，等价于 (left+right)/2
        MergeSort(arr, left, mid);
        MergeSort(arr, mid+1, right);
        Merge(arr,left,mid,right);
    }
    static void Merge(int[] arr, int left, int mid, int right)
    {
        int[] temp = new int[right - left + 1];
        int m = left;
        int n = mid + 1;
        int k = 0;

        while (m <= mid && n <= right)
        {
            if (arr[m] <= arr[n])
            {
                temp[k++] = arr[m++];
            }
            else
            {
                temp[k++] = arr[n++];
            }
        }
        while (m <= mid)
        {
            temp[k++] = arr[m++];
        }
        while (n <= right)
        {
            temp[k++] = arr[n++];
        }

        for (int i = 0; i < temp.Length; i++) arr[i + left] = temp[i];

    }
    
    static void ShellSort(int[] arr)
    {
        int n = arr.Length;

        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i++)
            {
                int key = arr[i];
                int preIndex = i - gap;
                while ( preIndex >= 0 && key < arr[preIndex])
                {
                    arr[preIndex + gap] = arr[preIndex];
                    preIndex -= gap;
                }
                arr[preIndex + gap] = key;
            }

        }
    }

    static void HeapSort(int[] arr)
    {
        int n = arr.Length;
        // n/2-1 为最后一个非叶节点
        for(int i = n/2-1; i>= 0; i--) HeapAdjust(arr, n, i);

        for(int i = n-1; i > 0; i--)
        {
            Swap(arr,0,i);
            HeapAdjust(arr, i, 0);
        }
    }
    // 调整以i为根的子树，len为当前堆有效长度
    static void HeapAdjust(int[] arr, int len, int i)
    {
        int largest = i;
        int l = 2 * i + 1;
        int r = 2 * i + 2;
        if (l < len && arr[l] > arr[largest]) largest = l;
        if (r < len && arr[r] > arr[largest]) largest = r;
        if(largest != i)
        {
            Swap(arr, i, largest);
            HeapAdjust(arr,len, largest);
        }
    }

    static void RestoreArr(int[] arr)
    {
        int[] original = { 5, 2, 9, 1, 5, 6, 7, 3, 11 };
        Array.Copy(original, arr, original.Length);
    }
}
