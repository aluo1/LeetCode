package com.aluo1.leetcode.easy;

import java.util.HashMap;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        romanToInt("X");
    }

    public static int romanToInt(String s) {
        Map<String, Integer> romanToIntDic = getRomanToIntDic();

        System.out.println(romanToIntDic);

        return 0;
    }

    /* a private method to create a dictionary for roman to integer */
    private static Map<String, Integer> getRomanToIntDic() {
        Map<String, Integer> romanToIntDic = new HashMap<String, Integer>();

        romanToIntDic.put("I", 1);
        romanToIntDic.put("IV", 4);
        romanToIntDic.put("V", 5);
        romanToIntDic.put("IX", 9);
        romanToIntDic.put("X", 10);
        romanToIntDic.put("XL", 40);
        romanToIntDic.put("L", 50);
        romanToIntDic.put("XC", 90);
        romanToIntDic.put("C", 100);
        romanToIntDic.put("CD", 400);
        romanToIntDic.put("D", 500);
        romanToIntDic.put("CM", 900);
        romanToIntDic.put("M", 1000);

        return romanToIntDic;
    }
}
