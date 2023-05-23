package com.example.notizapi;

import org.springframework.data.annotation.Id;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import java.time.Clock;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;

@Entity
public class Notiz {
    @Id
    @GeneratedValue(strategy= GenerationType.AUTO)
    private String id;
    private String titel;
    private String text;
    private String creationDate;
    private String tag;

    public Notiz(String id, String titel, String text, String tag) {
        super();
        this.id = id;
        this.titel=titel;
        this.text=text;
        DateTimeFormatter format = DateTimeFormatter.ofPattern("dd-MM-yyyy HH:mm:ss");
        creationDate=LocalDateTime.now(Clock.systemDefaultZone()).format(format);
        this.tag=tag;
    }

    public void setId(String id) {
        this.id = id;
    }
    public String getId(){
        return id;
    }
    public String getTitel() {
        return titel;
    }
    public void setTitel(String titel) {
        this.titel = titel;
    }
    public String getText() {
        return text;
    }
    public void setText(String text) {
        this.text = text;
    }
    public String getCreationDate() {
        return creationDate;
    }
    public void setCreationDate(String creationDate) {
        this.creationDate = creationDate;
    }
    public String getTag(){return tag;}
    public void setTag(String tag){this.tag=tag;}
}