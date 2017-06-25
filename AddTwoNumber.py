"""
    Author: An Luo
    email: aluo1.developer@gmail.com
    
    Notes: This code is not yet optimized.
    Problem Website: https://leetcode.com/problems/two-sum/
    Acknowledgement: This code is built upon the skeleton provided by LeetCode    
"""
# Definition for singly-linked list.
class ListNode(object):
    def __init__(self, x):
        self.val = x
        self.next = None

class AddTwoNumber(object):
    def addTwoNumbers(self, l1, l2):
        """
        :type l1: ListNode
        :type l2: ListNode
        :rtype: ListNode
        """
        result_node = ListNode(0)
        nodes = result_node
        add_one = False
        
        # while (l1 != None  and l2 != None):
        #     valSum = l1.val + l2.val
        #     if (add_one):
        #         valSum += 1
        #         add_one = False

        #     if (valSum >= 10):
        #         valSum %= 10
        #         add_one = True

        #     nodes.val = valSum

        #     # Move to the next node
        #     l1 = l1.next
        #     l2 = l2.next
        #     if (l1 == None):
        #         nodes.next = l2
        #         if (add_one):
        #             if (l2 != None):
        #                 if ((nodes.next.val+1) >= 10):
        #                     nodes.next.val = (nodes.next.val+1)%10
        #                     nodes.next.next = ListNode(1)
        #                 else:
        #                     nodes.next.val += 1
        #             else:
        #                 nodes.next = ListNode(1)
        #     elif (l2 == None):
        #         nodes.next = l1
        #         if (add_one):
        #             if (l1 != None):
        #                 if ((nodes.next.val+1) >= 10):
        #                     nodes.next.val = (nodes.next.val+1)%10
        #                     nodes.next.next = ListNode(1)
        #                 else:
        #                     nodes.next.val += 1
        #             else:
        #                 nodes.next = ListNode(1)
        #     else: 
        #         nodes.next = ListNode(0)
        #         # nodes = new_node 
        #         nodes = nodes.next

        while (l1 != None  or l2 != None):
            if (l1 != None and l2 != None):
                valSum = l1.val + l2.val
                l1 = l1.next
                l2 = l2.next
            elif (l1 != None):
                valSum = l1.val
                l1 = l1.next
            else:
                # This can only be l2 != None
                valSum = l2.val
                l1 = l2.next

            if (add_one):
                valSum += 1
                add_one = False

            if (valSum >= 10):
                valSum %= 10
                add_one = True

            nodes.val = valSum

            # Move to the next node
            l1 = l1.next
            l2 = l2.next

            if (l1 == None and l2 == None):
                nodes.next = None
            else:
                nodes.next = ListNode(0)
                nodes = nodes.next

        if (add_one):
            nodes.next = ListNode(1)

        return result_node

solution = AddTwoNumber()

l1 = ListNode(2)
l1.next = ListNode(4)
l1.next.next = ListNode(3)

l2 = ListNode(5)
l2.next = ListNode(6)
l2.next.next = ListNode(4)

solution.addTwoNumbers(l1, l2)

    