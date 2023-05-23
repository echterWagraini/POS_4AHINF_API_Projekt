package com.example.notizapi;

import org.springframework.data.annotation.Id;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import java.time.Clock;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

@Entity
public class Settings {
    public boolean darkMode;
    public String titleMDPrefix;

    public Settings(boolean darkMode, String titleMDPrefix) {
        this.darkMode=darkMode;
        this.titleMDPrefix=titleMDPrefix;
    }
    public boolean getDarkMode() {return darkMode;}
    public void setDarkMode(boolean darkMode) {this.darkMode = darkMode;}
    public String getTitleMDPrefix(){return titleMDPrefix;}
    public void setTitleMDPrefix(String titleMDPrefix){this.titleMDPrefix=titleMDPrefix;}
}