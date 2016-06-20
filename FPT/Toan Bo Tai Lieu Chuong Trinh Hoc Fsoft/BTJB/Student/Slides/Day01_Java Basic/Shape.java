package com.example.oop;

public abstract class Shape {
    private String Color;
    
    public Shape(String color) {
        this.setColor(color);
    }
    
    public String getColor() {
        return Color;
    }

    public void setColor(String color) {
        Color = color;
    }

    abstract public String draw();
}

