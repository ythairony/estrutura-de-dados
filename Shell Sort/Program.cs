using System.Collections;

public class Shell {
    public void ShellSort(int[] nums) {
        int h = 1;
        int n = nums.Length;
        
        while(h < n) {
                h = h * 4 + 1;
        }
        
        h = h / 3;
        int c, j;
        
        while (h > 0) {
            for (int i = h; i < n; i++) {
                c = nums[i];
                j = i;
                while (j >= h && nums[j - h] > c) {
                    nums[j] = nums[j - h];
                    j = j - h;
                }
                nums[j] = c;
            }
            h = h / 2;
        }
    }
}

public class Program {
    public static void Main() {
        int[] nums = new int[] {65, 40, 74, 84, 71, 96, 25, 61, 45, 73};
        Shell m = new Shell();
        m.ShellSort(nums);
    }
}

