using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrazyMathHelper : MonoBehaviour
{
    #region Methods: public

    public bool GetIsPalindrome(string text) {
        if (string.IsNullOrWhiteSpace(text)) {
            return false;
        }
        if (text.Length == 1) {
            return true;
        }
        bool isPalindrome = true;
        for (int i = 0, j = text.Length - 1; i < j; i++, j--) {
            if (text[i] != text[j]) {
                isPalindrome = false;
                break;
            }
        }
        return isPalindrome;
    }

    public List<int> GetRandomSortedArray(int lenght) {
        int[] array = new int[lenght];
        for (int i = 0; i < lenght; i++) { 
            array[i] = Random.Range(-500, 501);
        }
        int[] result = QuickSort(array, 0, array.Length);
        return result.ToList();
    }
    public List<int> GetRandomSorted2dArray(int lenght) {
        int[] array = new int[lenght];
        for (int i = 0; i < lenght; i++) {
            array[i] = Random.Range(-500, 501);
        }
        int[] result = QuickSort(array, 0, array.Length);
        return result.ToList();
    }

    #endregion

    #region Methods: private

    int[] QuickSort(int[] array, int start, int end) {
        if (start < end) {
            int pivot = Partition(array, start, end);
            QuickSort(array, start, pivot);
            QuickSort(array, pivot + 1, end);
        }
        return array;
    }
    void Swap(int[] array, int i, int j) {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
    int Partition(int[] array, int start, int end) {
        int pivot = array[start];
        int swapIndex = start;
        for (int i = start + 1; i < end; i++) {
            if (array[i] < pivot) {
                swapIndex++;
                Swap(array, i, swapIndex);
            }
        }
        Swap(array, start, swapIndex);
        return swapIndex;
    }

    #endregion

}
