package com.example;

public class Foo {
    private int x;
    
    public Foo(int x) {
        this.x = x;
    }
    
    public Foo(Foo x) {
        this.x = x.x;
    }
    
    public int getValue() {
        return x;
    }
    
    public void setValue(int value) {
        this.x = value;
    }
}
