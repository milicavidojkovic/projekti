package com.demo.demo.Service;

import org.jooq.DSLContext;
import org.jooq.Record;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Propagation;
import org.springframework.transaction.annotation.Transactional;

import javax.swing.*;
import java.time.LocalDateTime;
import java.time.ZoneOffset;
import java.util.List;

import static com.example.demo.jooq.Tables.AUTHOR;
import static com.example.demo.jooq.Tables.BOOK;

@Service
public class DemoService {
    private final DSLContext dsl;

    public DemoService(DSLContext dsl) {
        this.dsl = dsl;
    }

    @Transactional(readOnly = true, propagation = Propagation.SUPPORTS)
    public List<String> getAuthors() {
        return dsl.select(AUTHOR.FIRST_NAME, AUTHOR.LAST_NAME)
                .from(AUTHOR)
                .orderBy(AUTHOR.LAST_NAME.asc())
                .fetch(r -> r.get(AUTHOR.FIRST_NAME) + " " + r.get(AUTHOR.LAST_NAME));
    }


    @Transactional(readOnly = false, propagation = Propagation.REQUIRED)
    public int addBook(String title, Long authorId) {
        return dsl.insertInto(BOOK)
                .set(BOOK.TITLE, title)
                .set(BOOK.AUTHOR_ID, authorId)
                .set(BOOK.CREATED_AT, LocalDateTime.now().atOffset(ZoneOffset.UTC))
                .execute();
    }

    @Transactional(readOnly = true, propagation = Propagation.SUPPORTS)
    public Long getAuthorIdByName(String firstName, String lastName) {
        return dsl.select(AUTHOR.ID)
                .from(AUTHOR)
                .where(AUTHOR.FIRST_NAME.eq(firstName))
                .and(AUTHOR.LAST_NAME.eq(lastName))
                .fetchOne(AUTHOR.ID);
    }

    @Transactional(readOnly = false, propagation = Propagation.REQUIRED)
    public Long addAuthor(String authorName, String authorLastName) {
        return dsl.insertInto(AUTHOR)
                .set(AUTHOR.FIRST_NAME, authorName)
                .set(AUTHOR.LAST_NAME, authorLastName)
                .set(AUTHOR.CREATED_AT, LocalDateTime.now().atOffset(ZoneOffset.UTC))
                .returning(AUTHOR.ID)
                .fetchOne(AUTHOR.ID);
    }

}
