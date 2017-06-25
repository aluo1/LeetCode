package com.aluo1.leetcode.easy;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Main {

    public static void main(String[] args) {
        System.out.println(romanToInt("X"));
    }

    public static int romanToInt(String s) {
        Map<String, Integer> romanToIntDic = getRomanToIntDic();
        int valueInInt = 0;
        int i;

        for (i = 0; i < s.length()-1; i++) {
            char currentChar = s.charAt(i);
            System.out.println(i);
            if (currentChar == 'I') {
                char nextChar = s.charAt(i+1);
                if (nextChar == 'V') {
                    valueInInt += romanToIntDic.get("IV");
                    i++;
                } else if (nextChar == 'X') {
                    valueInInt += romanToIntDic.get("IX");
                    i++;
                } else {
                    valueInInt += romanToIntDic.get("I");
                }
            } else if (currentChar == 'X') {
                char nextChar = s.charAt(i+1);
                if (nextChar == 'L') {
                    valueInInt += romanToIntDic.get("XL");
                    i++;
                } else if (nextChar == 'C') {
                    valueInInt += romanToIntDic.get("XC");
                    i++;
                } else {
                    valueInInt += romanToIntDic.get("X");
                }
            } else if (currentChar == 'C') {
                char nextChar = s.charAt(i+1);
                if (nextChar == 'D') {
                    valueInInt += romanToIntDic.get("CD");
                    i++;
                } else if (nextChar == 'M') {
                    valueInInt += romanToIntDic.get("CM");
                    i++;
                } else {
                    valueInInt += romanToIntDic.get("C");
                }
            } else {
                valueInInt += romanToIntDic.get(currentChar);
            }
        }

        System.out.println(i);
        if (i != (s.length())) {
            valueInInt += romanToIntDic.get(s.charAt(i+1));
        }

//        System.out.println(romanToIntDic);

        return valueInInt;
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
