package com.demo.demo.Controller;


import com.demo.demo.Service.DemoService;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
public class DemoAppController {


    private final DemoService service;

    public DemoAppController(DemoService service) {
        this.service = service;
    }

    @GetMapping("/authors")
    public List<String> authors() {
        return service.getAuthors();
    }

    @PostMapping("/addBook")
    public int addBook(@RequestParam String title, @RequestParam String authorName, @RequestParam String authorLastName) {
        Long authorId = service.getAuthorIdByName(authorName, authorLastName);
        if(authorId == null){
            authorId = service.addAuthor(authorName, authorLastName);
        }
        return service.addBook(title, authorId);
    }

}
