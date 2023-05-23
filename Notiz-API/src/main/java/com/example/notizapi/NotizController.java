package com.example.notizapi;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.util.List;
import java.util.Optional;

@RestController
public class NotizController {
    @RequestMapping("/status")
    public String serviceTest(){
        return "Der Service funktioniert!";
    }

    @Autowired
    private NotizService notizService;

    @Autowired
    private SettingsService settingsService;

    @RequestMapping("/notiz")
    public List<Notiz> getallNotizen() {
        return notizService.getallNotizen();
    }


    @RequestMapping("/notiz/{id}")
    public Optional<Notiz> getNotiz(@PathVariable String id) {
        return notizService.getNotiz(id);
    }


    @RequestMapping(method= RequestMethod.POST, value="/notiz")
    public String addNotiz(@RequestBody Notiz notiz) {
        notizService.addNotiz(notiz);
        String response = "{\"success\": true, \"message\": Notiz has been added successfully.}";
        return response;
    }

    @RequestMapping(method = RequestMethod.PUT, value="/notiz/{id}")
    public String updateNotiz(@RequestBody Notiz notiz, @PathVariable String id) {
        notizService.updateNotiz(id, notiz);
        String response = "{\"success\": true, \"message\": Notiz has been updated successfully.}";
        return response;
    }

    @DeleteMapping(value="/notiz/{id}")
    public String deleteNotiz(@PathVariable String id) {
        notizService.deleteNotiz(id);
        String response = "{\"success\": true, \"message\": Notiz has been deleted successfully.}";
        return response;
    }

    @RequestMapping("/settings")
    public Settings getSettings() {
        return settingsService.getSettings();
    }

    @RequestMapping(method= RequestMethod.POST, value="/settings")
    public String updateSettings(@RequestBody Settings settings) {
        settingsService.addSettings(settings);
        String response = "{\"success\": true, \"message\": Settings have been updated successfully.}";
        return response;
    }


}
