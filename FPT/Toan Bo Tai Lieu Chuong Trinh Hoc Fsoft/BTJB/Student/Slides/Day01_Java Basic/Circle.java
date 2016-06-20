package com.example.oop;

public class Circle extends Shape {
    
    public Circle(String color) {
        super(color);
    }
    
    @Override
    public String draw() {
        return "I'm a " + this.getColor() + " circle.";
    }

}
