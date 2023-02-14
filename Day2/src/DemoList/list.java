
package DemoList;
import java.util.AbstractQueue;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Queue;
import java.util.Set;
import java.util.Stack;
import java.util.TreeSet;
public class list {
    public static void main(String[] args) {
        List<String> list1 = new ArrayList<>();
        list1.add("Nguyen Van A");
        list1.add("Nguyen Van B");
        list1.add("Nguyen Van C");
        list1.add("Nguyen Van D");
        for (String str : list1) {
            System.out.println(str);
        }
        list1.set(2, "Nguyen Dinh C");
        System.out.println(list1.get(2));
        list1.remove(2);
        for (String str : list1) {
            System.out.println(str);
        }
        list1.add(null);
        for (String str : list1) {
            System.out.println(str);
        }
        LinkedList<String> list2 = new LinkedList<>();
        list2.add("sa");
        list2.add("bf");
        list2.add(null);
        list2.add(null);
        list2.addLast("aaa");
        list2.add(4, "re");
        for (String str : list2) {
            System.out.println(str);
        }
        System.out.println("Next");
        Set<String> list3 = new HashSet<>();
        list3.add("Nguyen Van A");
        list3.add("Nguyen Van B");
        list3.add("Nguyen Van B");
        list3.add("Nguyen Van C");
        for (String string : list3) {
            System.out.println(string);
        };
        list3.remove("Nguyen Van A");
                for (String string : list3) {
            System.out.println(string);
        }
        System.out.println("Next 2");
        TreeSet<String> list4 = new TreeSet<>();
        list4.add("Nguyen Van E");
        list4.add("Nguyen Van W");
        list4.add("Nguyen Van F");
        list4.add("Nguyen Van A");
        list4.add("Nguyen Van B");
        list4.add("Nguyen Van K");
        list4.add("Nguyen Van O");
        list4.add("Nguyen Van P");
        list4.add("Nguyen Van R");
        list4.add("Nguyen Van E");
        for (String string : list4) {
            System.out.println(string);
            
        }
        System.out.println("Demo Hash Map");
        HashMap<Integer,String> user = new HashMap<>();
        user.put(1, "Nguyen Van A");
        user.put(2, "Nguyen Van G");
        user.put(3, "Nguyen Van C");
        user.put(4, "Nguyen Van R");
        user.put(5, "Nguyen Van E");
        for (Map.Entry<Integer, String> entry : user.entrySet()) {
            Integer key = entry.getKey();
            String value = entry.getValue();
            System.out.println("Key "+key+"=> "+value);
        }
        System.out.println("Demo Stack");
        Stack strc = new Stack();
        strc.push(4);
        strc.push("asdas");
        strc.push(null);
        System.out.println(strc.peek());
        System.out.println("Queue: ");
//        Queue<Integer> que = new Queue<Integer>();
//        que.add(10);
//        que.add(4);
//        que.add(5);
//        que.add(22);
//        System.out.println("TOp Queue: "+que.peek());
//        System.out.println("Queue");
//        System.out.println(que);
    }
}
