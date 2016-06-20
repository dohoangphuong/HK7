package com.example.oop;

public class Rectangle extends Shape {
    
    public Rectangle(String color) {
        super(color);
    }
    
    @Override
    public String draw() {
        return "I'm a " + this.getColor() + " rectangle.";
    }

}
