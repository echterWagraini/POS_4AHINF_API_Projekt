package com.example.notizapi;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Optional;

@Service
public class SettingsService {
    @Autowired
    private SettingsRepository settingsRepository;

    //private Settings settings=new Settings(null,false,"# ");

    public Settings getSettings() {return (Settings) this.settingsRepository.findAll().toArray()[0];}

    public void addSettings(Settings settings) {this.settingsRepository.save(settings);}
}
