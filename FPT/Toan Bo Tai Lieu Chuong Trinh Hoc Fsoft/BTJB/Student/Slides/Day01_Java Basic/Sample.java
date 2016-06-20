package com.example;

public class Sample {
    public static void main(String args[]) {
        Sample sample = new Sample();
        Foo f1 = new Foo(5);
        Foo f2 = new Foo(20);
        System.out.println("F1 Before: " + f1.getValue());
        System.out.println("F2 Before: " + f2.getValue());
        f1 = f2;
        sample.increase(f1, 10);
        System.out.println("F1 After: " + f1.getValue());
        System.out.println("F2 After: " + f2.getValue());
    }
    
    public void increase(Foo foo, int value) {
        foo.setValue(foo.getValue() + value);
    }
}
