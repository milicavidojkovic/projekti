package com.demo.demo;

import com.demo.demo.Controller.DemoAppController;
import com.example.demo.jooq.tables.records.AuthorRecord;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.DynamicPropertyRegistry;
import org.springframework.test.context.DynamicPropertySource;
import org.testcontainers.containers.PostgreSQLContainer;
import org.testcontainers.junit.jupiter.Container;
import org.testcontainers.junit.jupiter.Testcontainers;

import java.util.List;

import static org.assertj.core.api.Assertions.assertThat;

@Testcontainers
@SpringBootTest(properties = "spring.config.name=application-test")
class AuthorServiceTest {

    @Container
    static PostgreSQLContainer<?> postgres = new PostgreSQLContainer<>("postgres:16")
            .withDatabaseName("demo")
            .withUsername("postgres")
            .withPassword("postgres")
            .withInitScript("schema.sql"); // src/test/resources/schema.sql

    @DynamicPropertySource
    static void overrideProps(DynamicPropertyRegistry registry) {
        registry.add("spring.datasource.url", postgres::getJdbcUrl);
        registry.add("spring.datasource.username", postgres::getUsername);
        registry.add("spring.datasource.password", postgres::getPassword);
        registry.add("spring.jooq.sql-dialect", () -> "POSTGRES");

    }

    @Autowired
    DemoAppController authorService;

    @Test
    void findAll_returns_seeded_authors_sorted() {
        List<String> authors = authorService.authors();

        assertThat(authors).hasSize(2);
        assertThat(authors.get(0)).isEqualTo("Ivo Andric");
        assertThat(authors.get(1)).isEqualTo("Mesa Selimovic");
    }
}
