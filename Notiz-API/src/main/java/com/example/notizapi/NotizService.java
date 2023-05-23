package com.example.notizapi;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Optional;

@Service
public class NotizService {
    @Autowired
    private NotizRepository notizRepository;

    //private List<Notiz> notizen = new ArrayList<>(Arrays.asList());

    public List<Notiz> getallNotizen() {
        return (List<Notiz>) this.notizRepository.findAll();
    }

    public Optional<Notiz> getNotiz(String id) {
        return this.notizRepository.findById(id);
    }

    public void addNotiz(Notiz notiz) {
        this.notizRepository.save(notiz);
    }

    public void deleteNotiz(String id) { this.notizRepository.deleteById(id); }

    public void updateNotiz(String id, Notiz notiz) {
        /*this.autovermietungRepository.deleteById(id);
        auto.setId(1);  */
        this.notizRepository.save(notiz);
    }
}
