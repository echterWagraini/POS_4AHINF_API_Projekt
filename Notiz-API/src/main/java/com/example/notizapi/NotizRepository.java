package com.example.notizapi;

import org.springframework.data.mongodb.repository.MongoRepository;
import org.springframework.data.repository.CrudRepository;

public interface NotizRepository extends MongoRepository<Notiz, String> {

}
